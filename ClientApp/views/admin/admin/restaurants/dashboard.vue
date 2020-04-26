<template>
	<div class="p-3">	
		<div class="table">
			<div class="text-center">Restaurants</div>
			<div class="flex-row">
				<div class="col-1 text-center">Number</div>
				<div class="col-3 text-center">Name</div>
				<div class="col-3 text-center">Address</div>
				<div class="col-4 text-center">Manager</div>
				<div class="col-1 flex-row justify-content-around">
					Editing
				</div>
			</div>
			<div class="flex-row" v-for="(restaurant,index) in restaurants" :key="index">
				<div class="col-1 text-center">{{index+1}}</div>
				<div class="col-3 text-center">{{restaurant.name}}</div>
				<div class="col-3 text-center">{{restaurant.address}}</div>
				<div class="col-4 text-center">{{restaurant.manager.firstName}} {{restaurant.manager.lastName}}</div>
				<div class="col-1 flex-row justify-content-around">
					<div class="cursor-pointer" @click="deleteRestaurant(restaurant.restaurantId)"><icon icon="trash"/></div>
				</div>
			</div>
		</div>
	</div>
</template>
<script type="text/javascript">
export default{
	data(){
		return{
			restaurants:[]
		}
	},
	methods:{
		getRestaurants(){
			this.$http.get('admin/restaurants').then(response=>{
				this.restaurants=response.data;
				console.log(this.restaurants);
			});
		},
		deleteRestaurant(index){
			this.$http.delete('admin/restaurant/'+index).then(response=>{
				this.getRestaurants();
			});
		}
	},
	created(){
		this.getRestaurants();
	}
};
</script>
<style scoped>
input{
	background-color: transparent;
	border:transparent;
	display: flex;
	justify-content: center;
}
</style>