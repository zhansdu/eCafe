import Vue from 'vue'
import Vuex from 'vuex'
import actions from './actions'
import mutations from './mutations'
import state from './state'
import getters from './getters'

Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER'

const store = new  Vuex.Store({
	state,
	mutations,
	actions,
	getters
});
store.subscribe((mutation, state) => {
	var cache={
		user:state.user,
		city:state.city,
		editingRestaurant:state.editingRestaurant
	}
	localStorage.setItem('store', JSON.stringify(cache));
});
export default store;
