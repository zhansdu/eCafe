<template>
	<div>
		<div id="restaurant" class="flex-column" >
			<div class="grid bgPurple">
				<div class="flex-column align-items-center text-center">
					<div><icon icon="home" class="x15"/></div>
					<div class="x15">Адресс</div>
					<div class="x08">{{restaurant.address}}</div>
				</div>
				<div class="flex-column align-items-center text-center">
					<div><icon icon="phone-square" class="x15"/></div>
					<div class="x15">Контакты</div>
					<div class="x08">{{restaurant.contacts}}</div>
				</div>
				<div class="flex-column align-items-center text-center">
					<div><icon class="x15" icon="city"/></div>
					<div class="x15">Город</div>
					<div class="x08">{{restaurant.city.name}}</div>
				</div>
			</div>
			<div class="backgroundImage flex-column justify-content-center" :style="'background-image:url('+restaurant.image+');'">
				<div class="half-width flex-column align-items-center ml-auto" style="height:80%;">
					<div class="innerDiv flex-column p-3">
						<div>{{restaurant.name}}</div>
						<div>{{restaurant.bigDescription}}</div>
					</div>
				</div>
			</div>
			<div class="grid bgPurple">
				<div class="flex-column align-items-center text-center">
					<div><icon icon="clock" class="x15"/></div>
					<div class="x15">Время работы</div>
					<div class="x08"> Пн-Вс - с {{timeToString(restaurant.startTime,true)}} до {{timeToString(restaurant.endTime,true)}}</div>
				</div>
				<div class="flex-column align-items-center text-center">
					<div><icon icon="tags" class="x15"/></div>
					<div class="x15">Средний чек</div>
					<div class="x08">{{restaurant.avarageMoney}}</div>
				</div>
				<div class="flex-column align-items-center text-center">
					<div><icon icon="utensils" class="x15"/></div>
					<div class="x15">Кухня</div>
					<div class="x08">{{restaurant.kitchen}}</div>
				</div>
			</div>
		</div>
		<div class="flex-column align-items-center m-3"><button class="squareButton x15 purple-button ml-3" @click="setConfirmation()">Order a table</button></div>
		<div  id="tables"></div>
		<div class="w-100" v-if="confirmed">
			<div class="p-2 flex-column align-items-center">
				<table class="table">
					<tr class="text-center">TABLES</tr>
					<tr>
						<td>Time / Table</td>
						<td v-for="(time,index) in times" :key="index">{{presentTime(time)}}</td>
					</tr>
					<tr v-for="(table,index) in orderTimes" :key="index">
						<td>#{{table.table.number}} / {{table.table.seatsCount}} seats</td>
						<td class="cursor-pointer" v-for="(time,index) in table.times" :key="index" :class="time.active ? 'active' : 'free'" @click="setOrderTime(table.table,time)">
						</td>
					</tr>
				</table>
			</div>
			<div id="food"></div>
			<div v-if="orderStartTime!=null">
				<div class="flex-row flex-wrap align-items-center">
					<div class="foodCard m-2 p-3" v-for="(item,index) in menu">
						<div class="align-self-center">{{item.type}} {{item.name}}</div>
						<hr/>
						<div> {{item.description}}</div>
						<div class="w-100 flex-row mt-auto align-self-center justify-content-around">
							<div>{{item.price}} тг</div>
							<button class="purple-button" @click="addFood(item)">Add</button>
						</div>
					</div>
				</div>
				<div class="table m-2">
					<div class="text-center">Order details</div>
					<div class="flex-column">
						<div class="flex-row">
							<div class="col-4">
								<span>Order time</span>
								<input type="text" disabled :value="'from '+timeToString(orderStartTime)+' to '+timeToString(orderEndTime)"/>
							</div>
							<div class="col-4">
								<span>Restaurant</span>
								<input type="text" disabled :value="restaurant.name"/>
							</div>
							<div class="col-4">
								<span>Table number</span>
								<input type="text" disabled :value="table.number"/>
							</div>
						</div>
						<div class="flex-row">
							<div class="col-12">
								<span>Food</span>
								<li class="dropdown-item flex-row align-items-center" v-for="(food,index) in $store.state.food">
									<div style="overflow:hidden;width:350px;">
										{{food.type}} {{food.name}} {{food.price}}
									</div>
									<icon icon="trash" class="cursor-pointer" @click="removeFood(index)"/>
								</li>
								<span>Total : {{total}}</span>
							</div>
						</div>
						<div class="flex-row justify-content-center">
							<button class="purple-button" @click="confirm()">Confirm</button>
						</div>
					</div>
				</div>
			</div>	
		</div>
	</div>			
</template>
<script type="text/javascript">
export default{
	props:{
		restaurant:Object
	},
	data(){
		return{
			times:[],
			orderTimes:[],
			orderStartTime:null,
			orderEndTime:null,
			table:null,
			menu:null,
			order:{
				restaurantId:this.restaurant.restaurantId,
				clientId:this.$user.user().clientId
			},
			confirmed:false,
			date:null
		}
	},
	computed:{
		total(){
			var int=0;
			if(this.$store.state.food.length>0){
				this.$store.state.food.forEach(elem=>{
					int+=elem.price;
				})
			}
			return int;
		},
	},
	methods:{
		setTimes(object,date){ /*from where to where in table*/
			var from = new Date(date),
			to = new Date(date);
			to.setHours(to.getHours()-1);
			from.setMinutes(0);
			from.setSeconds(0);
			while(from <= to){

				object.push({time:new Date(from),active:false});
				
				from.setHours( from.getHours() + 1 );
			}
		},
		async getTables(){/*tables in tables and green blocs (orderTimes) */
			var tables;
			await this.$http.get('client/tables/'+this.restaurant.restaurantId).then(response=>tables=response.data);
			tables.forEach(table=>{
				var times= [];
				this.setTimes(times);
				this.orderTimes.push({table:table,times:times});
			})
		},
		async setOrderTimes(){ /*main function on begining */
			// making matrix
			this.setTimes(this.times);
			await this.getTables();
			// done with matrix
			// get orders
			var orders;
			var now=new Date();
			await this.$http.post('client/orders/'+this.restaurant.restaurantId,now).then(response=>{orders=response.data;});
			// done getting orders
			// set red blocks
			var vm=this;
			orders.forEach(order=>{
				var table = vm.orderTimes.find((e)=>e.table.tableId==order.tableId);
				var orderTime=new Date(order.startTime);
				console.log(orderTime);
				var time= table.times.find((e)=>e.time.getHours()==orderTime.getHours());
				if(time){
					time.active=true;
					console.log(time);
				}
			})
			// everything done
		},
		setOrderTime(table,time){
			// when clicking green blocks
			if(!this.table){
				time.active=true;
				this.orderStartTime=time.time;
				var timex=new Date(JSON.parse(JSON.stringify(time.time)));
				timex.setHours(timex.getHours()+1);
				this.orderEndTime=timex;
				this.table=table;
				this.scrollTo('food');
			}
			else{
				if(time.time==this.orderStartTime){
					this.orderStartTime=null;
					time.active=false;
					this.table=null;
				}
			}
		},
		timeToString(time,boolean){
			// representative time supporting method for presentTime
			var str='';
			time=new Date(time);
			
			var hours = time.getHours();
			
			str+=(hours).pad(2);
			if(boolean){
				var minutes = time.getMinutes();
				str+=' : '+(minutes).pad(2);
			}
			return str;
		},
		async getFood(){
			// get menu
			this.$http.get('client/food/restaurant/'+this.restaurant.restaurantId).then(response=>{
				this.menu=response.data;
			})
		},
		addFood(food){
			this.$store.commit('addFood',food);
		},
		removeFood(index){
			this.$store.commit('removeFood',index)
		},
		scrollTo(link){
			var yOffset=-120;
			const element = document.getElementById(link);
			const y = element.getBoundingClientRect().top + window.pageYOffset + yOffset;
			window.scrollTo({top: y, behavior: 'smooth'});
		},
		presentTime(time){
			// respresentative time in matrix
			var then = new Date(JSON.parse(JSON.stringify(time.time)));
			then.setHours(then.getHours()+1);
			return this.timeToString(time.time,false)+' - '+this.timeToString(then,false);
		},
		confirm(){
			this.order.active=true;
			this.order.startTime=this.orderStartTime;
			this.order.endTime=this.orderEndTime;
			this.order.tableId=this.table.tableId;
			console.log(this.order.startTime);
			// this.$http.post('client/order',this.order).then(response=>alert(response.statusText));
		},
		setConfirmation(){
			// checks if user's logged in 
			if(this.$user.authenticated()){
				this.confirmed=true;
				this.scrollTo('tables')
			}
			else{
				alert('You need to login first');
			}
		}
	},
	created(){
		this.restaurant.image="../static/bar.png";
		this.setOrderTimes();
		this.getFood();
		console.log(new Date());

	},
	mounted(){
		this.scrollTo('restaurant');
	}
};
</script>
<style scoped>
.foodCard{
	width:180px;
	height: 250px;
	display: flex;
	flex-direction: column;
	border:1px solid gray;
	border-radius: 7px;
	background-color:rgba(0,0,0,.2);

}
.active{
	background-color: red;
}
.free{
	background-color: green;
}
table{
	display: initial !important;
}
table,td{
	border:5px solid white;
}
.image{
	width:100%;
	min-width: 500px;
}
.grid{
	display: grid;
	grid-template-columns: 33.3% 33.3% 33.3%;
}
.grid > div:nth-child(n+2){
	border-left:1px solid black;
}
.bgPurple{
	background: #FFE8E8;
}
.backgroundImage{
	background-repeat: no-repeat;
	background-size: cover;
	min-height: 210px;
	height:33vw;
}
.innerDiv{
	height: 100%;
	width:80%;
	background-color: rgba(255,255,255,0.5);
	overflow: scroll;
}
@media only screen and (min-width: 1185px){
	.innerDiv{
		justify-content: space-around;
	}
}
</style>