const mutations={
	clearStore(state){
		Object.keys(state).forEach(key => {
			if(Array.isArray(state[key])){
				state[key]=[]
			}else{
				state[key] = {}
			}
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
	},
	setCity(state,data){
		state.city=data;
	},
	addFood(state,data){
		console.log(state.food);
		state.food.push(data);
	},
	removeFood(state,index){
		state.food.splice(index,1);
	}
}
export default mutations;