<template>
	<div class="p-3">
		<div class="table">
			<div class="text-center">ADD A RESTAURANT</div>
			<div class="flex-column">
				<div class="flex-row">
					<div class="col-4">
						<input type="text" placeholder="Name" v-model="restaurant.name"/>
					</div>
					<div class="col-4">
						<input type="text" placeholder="Address" v-model="restaurant.address">
					</div>
					<div class="col-4">
						<customSelect :options="managers.data" placeholder="Manager " v-model="restaurant.manager"/>
					</div>
				</div>
				<div class="flex-row justify-content-center">
					<button class="purple-button" @click="confirm()">Add</button>
				</div>
			</div>
		</div>
	</div>
</template>
<script type="text/javascript">
import customSelect from '../../../../components/customSelect'
export default{
	components:{customSelect},
	data(){
		return{
			restaurant:{},
			managers:[]
		}
	},
	methods:{
		confirm(){
			console.log(this.restaurant)
			this.$http.post('admin/restaurant',this.restaurant).then(response=>{
				alert(response.statusText)
			})
		}
	},
	async created(){
		this.managers=await this.$http.get('admin/managers');
		this.managers.data.forEach(element=>{
			element.label=element.firstName+' '+element.lastName;
		})
	}
};
</script>
<style scoped>
input{
	width: 100%;
}
</style>