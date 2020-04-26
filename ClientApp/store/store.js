import Vue from 'vue'
import Vuex from 'vuex'
import actions from './actions'
import mutations from './mutations'
import state from './state'

Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER'

const store = new  Vuex.Store({
	state,
	mutations,
	actions
});
store.subscribe((mutation, state) => {
	var cache=JSON.stringify(state);
	localStorage.setItem('store', cache);
});
export default store;
