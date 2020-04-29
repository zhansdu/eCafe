<template>
	<div class="p-3">	
		<div class="table">
			<div class="text-center">Food</div>
			<div class="flex-row">
				<div class="col-1 text-center">Number</div>
				<div class="col-4 text-center">Name</div>
				<div class="col-3 text-center">Type</div>
				<div class="col-2 text-center">Price</div>
				<div class="col-2 flex-row justify-content-around">
					Editing
				</div>
			</div>
			<div class="flex-row" v-for="(food,index) in menu" :key="index">
				<div class="col-1 text-center">{{index+1}}</div>
				<div class="col-4 text-center">{{food.name}}</div>
				<div class="col-3 text-center">{{food.type}}</div>
				<div class="col-2 text-center">{{food.price}}</div>
				<div class="col-2 flex-row justify-content-around">
					<div class="cursor-pointer" @click="editFood(food)"><icon icon="pen"/></div>
					<div class="cursor-pointer" @click="deleteFood(food.foodId)"><icon icon="trash"/></div>
				</div>
			</div>
		</div>
	</div>
</template>
<script type="text/javascript">
import goTo from '../../../../mixins/goTo'
export default{
	mixins:[goTo],
	data(){
		return{
			menu:[]
		}
	},
	methods:{
		getMenu(){
			this.$http.get('manager/food/'+this.$store.state.editingRestaurant.restaurantId).then(response=>{
				this.menu=response.data;
			});
		},
		editFood(food){
			this.goTo('food.settings',{edit:food});
		},
		deleteFood(index){
			this.$http.delete('manager/food/'+index).then(response=>{
				this.getMenu();
			});
		}
	},
	created(){
		this.getMenu();
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