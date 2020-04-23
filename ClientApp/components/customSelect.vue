<template>
	<select>
		<option disabled selected class="d-none" v-if="placeholder">{{placeholder}}</option>
		<option v-for="(option,index) in options" :key="index" @click="handleClick(option)">{{option.label}}</option>
	</select>
</template>
<script type="text/javascript">
export default{
	props:{
		placeholder:String,
		value:Object,
		options:Array
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
	padding:2.5px;
}
</style>