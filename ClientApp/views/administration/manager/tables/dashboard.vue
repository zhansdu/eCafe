<template>
	<div class="p-3">	
		<table class="table">
			<tr class="text-center">TABLES</tr>
			<tr>
				<td>Table / Time</td>
				<td v-for="(time,index) in time" :key="index">{{time.getHours()}}</td>
			</tr>
			<tr v-for="(table,index) in tables" :key="index">
				<td>{{table.number}}</td>
				<td></td>
			</tr>
		</table>
	</div>
</template>
<script type="text/javascript">
export default{
	data(){
		return{
			tables:[],
			time:[],
			orderTimes:[]
		}
	},
	methods:{
		setTime(){
			var from  = new Date(this.$store.state.editingRestaurant.startTime),
			to    = new Date(this.$store.state.editingRestaurant.endTime),
			dates = [];

			while(from <= to){
				from.setMinutes(0);
				from.setSeconds(0);

				dates.push(new Date(from));
				
				from.setHours( from.getHours() + 1 );
			}
			this.time=dates;
		},
		async getTables(){
			await this.$http.get('manager/tables/'+this.$store.state.editingRestaurant.restaurantId).then(response=>this.tables=response.data);
		},
		async setOrderTimes(){
			var orders; 
			await this.$http.get('manager/orders/'+this.$store.state.editingRestaurant.restaurantId,new Date.now()).then(response=>orders=response.data);
		}
	},
	created(){
		this.setTime();
		this.getTables();
	}
};
</script>
<style scoped>
table{
	display: initial !important;
}
</style>