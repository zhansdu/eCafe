const mutations={
	initializeStore(state){
		if(localStorage.getItem('store')){
			this.replaceState(Object.assign(state, JSON.parse(localStorage.getItem('store'))));
		}
	},
	setUser(state,data){
		state.user=data;
	}
}
export default mutations;