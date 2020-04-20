const goTo={
	methods:{
		goTo(place,props){
			this.$router.push({name:place,params:props});
			this.$emit('close');
		}
	}
}
export default goTo;