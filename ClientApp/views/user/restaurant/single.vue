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
					<div><icon class="cursor-pointer x15" icon="comment-dots" @click="scrollTo('tables')"/></div>
					<div class="x15">Столики</div>
					<div class="x08">Online оформление заявки </div>
					<div class="x08">на проведение мероприятия</div>
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
		<div class="w-100" v-if="$user.authenticated()">
			<div class="p-2 flex-column align-items-center" id="tables">
				<table class="table">
					<tr class="text-center">TABLES</tr>
					<tr>
						<td>Table / Time</td>
						<td v-for="(time,index) in times" :key="index">{{timeToString(time.time,false)}}</td>
					</tr>
					<tr v-for="(table,index) in orderTimes" :key="index">
						<td>#{{table.table.number}} / {{table.table.seatsCount}} seats</td>
						<td class="cursor-pointer" v-for="(time,index) in table.times" :key="index" :class="time.active ? 'active' : 'free'" @click="setOrderTime(table,time)">
						</td>
					</tr>
				</table>
			</div>
			<div id="food"></div>
			<div v-if="orderTime!=null">
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
							<div class="col-6">
								<input type="number" placeholder="Number" v-model="table.number"/>
							</div>
							<div class="col-6">
								<input type="number" placeholder="Seats count" v-model="table.seatsCount">
							</div>
						</div>
						<div class="flex-row justify-content-center">
							<button class="purple-button" @click="confirm()">{{this.editing ? 'Edit' : 'Add'}}</button>
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
			orderTime:null,
			table:null,
			menu:null,
		}
	},
	methods:{
		setTimes(){
			var from  = new Date(this.restaurant.startTime),
			to    = new Date(this.restaurant.endTime),
			dates = [];

			while(from <= to){
				from.setMinutes(0);
				from.setSeconds(0);

				dates.push({time:new Date(from),active:false});
				
				from.setHours( from.getHours() + 1 );
			}
			this.times=dates;
		},
		async getTables(){
			var tables;
			await this.$http.get('client/tables/'+this.restaurant.restaurantId).then(response=>tables=response.data);
			tables.forEach(table=>{
				this.orderTimes.push({table:table,times:JSON.parse(JSON.stringify(this.times))});
			})
		},
		async setOrderTimes(){
			this.setTimes();
			await this.getTables();
			var orders;
			var now=new Date();
			await this.$http.post('client/orders/'+this.restaurant.restaurantId,now).then(response=>orders=response.data);
			var vm=this;
			orders.forEach(order=>{
				var table = vm.orderTimes.find((e)=>e.table.tableId==order.tableId);
				var time= table.times.find((e)=>e.time==order.startTime)
				if(time){
					time.active==true;
				}
			})
		},
		setOrderTime(table,time){
			if(!time.active){
				this.orderTime=time.time;
				time.active=true;
				this.scrollTo('food');
			}else{
				if(time==this.orderTime){
					this.orderTime=null;
					time.active=false;
				}
			}
			this.table=table;
		},
		timeToString(time,boolean){
			var str='';
			time=new Date(time);
			
			var hours = time.getHours();
			
			str+=(hours+6).pad(2);
			if(boolean){
				var minutes = time.getMinutes();
				str+=' : '+(minutes).pad(2);
			}
			return str;
		},
		async getFood(){
			this.$http.get('client/food/restaurant/'+this.restaurant.restaurantId).then(response=>{
				this.menu=response.data;
			})
		},
		addFood(food){
			this.$store.commit('addFood',food);
		},
		scrollTo(link){
			var yOffset=-120;
			const element = document.getElementById(link);
			const y = element.getBoundingClientRect().top + window.pageYOffset + yOffset;
			window.scrollTo({top: y, behavior: 'smooth'});
		}
	},
	created(){
		this.restaurant.image="../static/bar.png";
		this.setOrderTimes();
		this.getFood();
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