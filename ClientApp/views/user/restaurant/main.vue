<template>
	<div class="flex-column">
		<img src="../../../assets/images/tarelka.png" width="100%" />
		<div v-if="restaurants.length==0" class="flex-column align-items-center justify-content-center h-100">
			<h3>Sorry, there are no restaurants</h3>
		</div>
		<div class="restaurantGrid" style="margin-top:2vw;">
			<div class="restaurantCard p-3" v-for="(restaurant,index) in restaurants" :key="index">	
				<div class="x15 align-self-center mt-1">{{restaurant.name}}</div>
				<div>
					<div class="line"/>
					<div class="flex-column mt-1">
						<div>Working time : {{getTime(restaurant.startTime)}} - {{getTime(restaurant.endTime)}}</div>
						<div>Kitchen : {{restaurant.kitchen}}</div>
						<div>City: {{restaurant.city.name}}</div>
						<div>About restaurant :<br> {{restaurant.littleDescription}}</div>
					</div>
				</div>
				<button class="button align-self-center text-center cursor-pointer mt-auto" @click="more(restaurant)">More</button>
			</div>
		</div>
	</div>
</template>
<script type="text/javascript">
import goTo from '../../../mixins/goTo'
import {mapGetters} from 'vuex'
export default{
	mixins:[goTo],
	data(){
		return{
			restaurants:[]
		}
	},
	computed:{
		...mapGetters({
			city: 'getCity'
		})
	},
	watch:{
		city:function(){
			this.getRestaurants();
		}
	},
	methods:{
		getRestaurants(){
			if(Object.keys(this.$store.state.city).length!=0){ //checks if not empty
				this.$http.get('client/restaurants/'+this.$store.state.city.cityId).then(response=>{
					this.restaurants=response.data;
				});
			}
			else{
				this.$http.get('client/restaurants').then(response=>{
					this.restaurants=response.data;
					console.log(response.data);
				});
			}
		},
		getTime(time){
			time=new Date(time);
			var hours = time.getHours();
			var minutes = time.getMinutes();
			return (hours).pad(2)+' : '+(minutes).pad(2);
		},
		more(restaurant){
			this.goTo('client.restaurant',{restaurant:restaurant})
		}
	},
	created(){
		this.getRestaurants();
	}

};
</script>
<style scoped>
.restaurantCard{
	background: linear-gradient(180deg, #FFFFFF 0%, rgba(255, 255, 255, 0) 100%), #FFE9D6;
	border-radius: 3px;
	display: flex;
	flex-direction: column;
	height:300px;
}
.line{
	border:1px solid black;
}
.button{
	border-radius: 10em;
	border-color: transparent;
	padding:3px;
	background-color: rgba(0,0,0,0.5);
	width:100px;
}
.squareButton{
	border-color: transparent;
}
.restaurantGrid{
	display: grid;
	grid-template-columns: 33% 33% 33%;
	grid-gap: 1vw;
}
</style>