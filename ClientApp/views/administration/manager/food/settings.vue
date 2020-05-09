<template>
	<div class="p-3">
		<div class="table">
			<div class="text-center">{{this.edit ? 'EDIT FOOD':'ADD FOOD'}}</div>
			<div class="flex-column">
				<div class="flex-row">
					<div class="col-4">
						<input type="text" placeholder="Name" v-model="food.name"/>
					</div>
					<div class="col-4">
						<input type="text" placeholder="Type" v-model="food.type">
					</div>
					<div class="col-4">
						<input type="number" placeholder="Price" v-model="food.price">
					</div>
				</div>
				<div class="flex-row">
					<div class="col-12">
						<textarea placeholder="Description" v-model="food.description"></textarea>
					</div>
				</div>
				<div class="flex-row justify-content-center">
					<button class="purple-button" @click="confirm()">{{this.edit ? 'Edit':'Add'}}</button>
				</div>
			</div>
		</div>
	</div>
</template>
<script type="text/javascript">
export default{
	props:{
		edit:Object
	},
	data(){
		return{
			food:this.edit || {
				restaurantId:this.$store.state.editingRestaurant.restaurantId,
				cityId:this.$store.state.editingRestaurant.cityId
			}
		}
	},
	methods:{
		confirm(){
			if(this.edit){
				this.$http.put('manager/food',this.food).then(response=>{
					alert(response.statusText);
				})
			}
			else{
				this.$http.post('manager/food',this.food).then(response=>{
					alert(response.statusText)
				})
			}
		}
	}
};
</script>
