<template>
	<div class="p-3">	
		<div class="table">
			<div class="text-center">CLIENTS</div>
			<div class="flex-row">
				<div class="col-6 text-center">Number</div>
				<div class="col-6 text-center">Full name</div>
			</div>
			<div class="flex-row" v-for="(client,index) in clients" :key="index">
				<div class="col-6 text-center">{{index+1}}</div>
				<div class="col-6 text-center">{{client.firstName}} {{client.lastName}}</div>
			</div>
		</div>
	</div>
</template>
<script type="text/javascript">
export default{
	data(){
		return{
			clients:[]
		}
	},
	methods:{
		getClients(){
			this.$http.get('admin/clients').then(response=>{
				this.clients=response.data;
				console.log(this.clients);
			});
		}
	},
	created(){
		this.getClients();
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