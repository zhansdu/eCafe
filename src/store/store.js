import Vue from 'vue'
import Vuex from 'vuex'

import state from './state'
import mutations from './mutations'
import actions from './actions'

Vue.use(Vuex);

const store = new  Vuex.Store({
	state:state,
	mutations:mutations,
	actions:actions
});

store.subscribe((mutation, state) => {
	var cache=JSON.stringify(state);
	localStorage.setItem('store', cache);
});

export default store;