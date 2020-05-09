<template>
	<div class="h-100">
		<div class="flex-row justify-content-center align-items-center w-100 h-100" v-if="food.length==0">PLEASE SELECT A CITY OR A RESTAURANT</div>
		<div class="flex-row flex-wrap align-items-center" v-else>
			<div class="foodCard m-2 p-3" v-for="(item,index) in food">
				<div class="align-self-center">{{item.type}} {{item.name}}</div>
				<hr/>
				<div> {{item.description}}</div>
				<div class="w-100 flex-row mt-auto align-self-center justify-content-around">
					<div>{{item.price}} тг</div>
					<button class="purple-button" @click="addFood(item)">Add</button>
				</div>
			</div>
		</div>
	</div>
</template>
<script type="text/javascript">
import goTo from '../../../mixins/goTo'
import {mapGetters} from 'vuex'
export default{
	mixins:[goTo],
	props:{
		restaurantId:Number
	},
	data(){
		return{
			food:[]
		}
	},
	computed:{
		...mapGetters({
			city: 'getCity'
		})
	},
	watch:{
		city:function(){
			this.getFood();
		}
	},
	methods:{
		getFood(){
			if(this.restaurantId!=null){
				this.$http.get('client/food/restaurant/'+this.restaurantId).then(response=>this.food=response.data);
			}
			else if(Object.keys(this.$store.state.city).length!=0){ //checks if not empty
				this.$http.get('client/food/city/'+this.$store.state.city.cityId).then(response=>{
					this.food=response.data;
				});	
			}
		},
		addFood(food){
			this.$store.commit('addFood',food);
		}
	},
	created(){
		this.getFood();
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
</style>