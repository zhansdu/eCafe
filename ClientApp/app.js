import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store/store'
import { sync } from 'vuex-router-sync'
import App from './App'
import { FontAwesomeIcon } from './icons'

// Registration of global components
Vue.component('icon', FontAwesomeIcon)

class user{
	login(user){
		store.commit('setUser',user);
	}
	authenticated(){
		return Object.keys(store.state.user).length!=0;
	}
	user(){
		return store.state.user;
	}
	logout(){
		store.commit('clearStore');
	}
	role(){
		return this.user().role;
	}
}

Vue.prototype.$user=new user();
Vue.prototype.$http = axios.create({
	baseURL:'https://localhost:5001/api'
});

Number.prototype.pad = function(size) {
    var s = String(this);
    while (s.length < (size || 2)) {s = "0" + s;}
    return s;
}

const app = new Vue({
	store,
	router,
	...App,
})

export {
	app,
	router,
	store
}
