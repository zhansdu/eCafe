<template>
	<select>
		<option disabled selected class="d-none" v-if="placeholder">{{placeholder}}</option>
		<option v-for="(option,index) in options" :key="option" @click="handleClick(option)"></option>
	</select>
</template>
<script type="text/javascript">
export default{
	props:{
		placeholder:String,
		value:Object
	},
	data(){
		return{
			options:Array
		}
	},
	methods:{
		handleClick(option){
			this.$emit('input',option)
		}
	}
};
</script>
<style scoped>
	select{
		border:1px solid black;
		padding:3px;
	}
</style>