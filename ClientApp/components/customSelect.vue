<template>
	<select>
		<option value="" disabled selected v-if="placeholder">{{placeholder}}</option>
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