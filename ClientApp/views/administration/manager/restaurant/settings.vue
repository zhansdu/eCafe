<template>
	<div class="p-3">
		<div class="table">
			<div class="text-center">EDIT A RESTAURANT</div>
			<div class="flex-column">
				<div class="flex-row">
					<div class="col-6">
						<label>Name</label>
						<input type="text" v-model="restaurant.name"/>
					</div>
					<div class="col-3">
						<label >Work start time</label>
						<input type="time" v-model="time.start">
					</div>
					<div class="col-3">
						<label>Work end time</label>
						<input type="time" v-model="time.end">
					</div>
				</div>
				<div class="flex-row">
					<div class="col-12">
						<label>Description</label>
						<textarea placeholder="Description" v-model="restaurant.description"/>
					</div>
				</div>
				<div class="flex-row justify-content-center">
					<button class="purple-button" @click="confirm()">Edit</button>
				</div>
			</div>
		</div>
	</div>
</template>
<script type="text/javascript">
export default{
	data(){
		return{
			restaurant:this.$store.state.editingRestaurant,
			time:{
				start:{},
				end:{}
			},
		}
	},
	methods:{
		changeFile(event){
			this.file=event.target.files;
		},
		setTimeToDate(time,date){
			date.setHours(time.split(':')[0]);
			date.setMinutes(time.split(':')[1]);
			date.setSeconds(0);
			return date;
		},
		confirm(){
			var start=this.setTimeToDate(this.time.start,new Date());
			var end=this.setTimeToDate(this.time.end,new Date());			
			this.restaurant.startTime=start;
			this.restaurant.endTime=end;

			this.$http.put('manager/restaurant',this.restaurant).then(response=>{
				alert(response.statusText);
				this.$store.commit('setEditingRestaurant',this.restaurant);
			})
		}
	}
};
</script>
<style scoped>
label{
	width: 100%;
	display: flex;
	align-items:center;
	justify-content: center;
}
</style>