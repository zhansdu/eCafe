<template>
	<div class="p-3">	
		<div class="table">
			<div class="text-center">MANAGERS</div>
			<div class="flex-row">
				<div class="col-1 text-center">Number</div>
				<div class="col-3 text-center">Phone number</div>
				<div class="col-3 text-center">Email</div>
				<div class="col-4 text-center">Full name</div>
				<div class="col-1 flex-row justify-content-around">
					Editing
				</div>
			</div>
			<div class="flex-row" v-for="(manager,index) in managers" :key="index">
				<div class="col-1 text-center">{{index+1}}</div>
				<div class="col-3 text-center">{{manager.phoneNumber}}</div>
				<div class="col-3 text-center">{{manager.email}}</div>
				<div class="col-4 text-center">{{manager.firstName}} {{manager.lastName}}</div>
				<div class="col-1 flex-row justify-content-around">
					<div class="cursor-pointer" @click="deleteManager(manager.managerId)"><icon icon="trash"/></div>
				</div>
			</div>
		</div>
	</div>
</template>
<script type="text/javascript">
export default{
	data(){
		return{
			managers:[]
		}
	},
	methods:{
		getManagers(){
			this.$http.get('admin/managers').then(response=>{
				this.managers=response.data;
			});
		},
		deleteManager(index){
			this.$http.delete('admin/manager/'+index).then(response=>{
				this.getManagers();
			});
		}
	},
	created(){
		this.getManagers();
	}
};
</script>
<style scoped>
</style>