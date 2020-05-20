<template>
	<select>
		<option disabled selected class="d-none" v-if="placeholder">{{place}}</option>
		<option v-for="(option,index) in options" :key="index" @click="handleClick(option)">{{option.label}}</option>
	</select>
</template>
<script type="text/javascript">
export default{
	props:{
		placeholder:String,
		strValue:String,
		options:Array,
		onChange:Function,
		value:Object
	},
	computed:{
		place(){
			if(this.value!=null){
				if(Object.keys(this.value).length>0){
					return this.value.label
				}
				else{
					return this.placeholder
				}
			}
			else{
				return this.placeholder
			}
		}
	},
	methods:{
		handleClick(option){
			this.$emit('input',option[this.strValue] || option)
			if(this.onChange!=null){
				this.onChange();
			}
		}
	}
};
</script>
<style scoped>
select{
	padding:2.5px;
	width:100%;
}
</style>