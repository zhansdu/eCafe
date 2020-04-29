const mutations={
	clearStore(state){
		Object.keys(state).forEach(key => {
			state[key] = {}
		})
	},
	initializeStore(state){
		if(localStorage.getItem('store')){
			this.replaceState(Object.assign(state, JSON.parse(localStorage.getItem('store'))));
		}
	},
	setUser(state,data){
		state.user=data;
	},
	setEditingRestaurant(state,data){
		state.editingRestaurant=data;
	}
}
export default mutations;