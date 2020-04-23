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
	constructor(){}
	create(user){
		this.user=user;
	}
	login(){
		this.loggedIn=true;
	}
	authenticated(){
		return this.loggedIn;
	}
	logout(){
		this.loggedIn=false;
	}
	user(){
		return this.user;
	}
	role(){
		return this.user.role;
	}
}

Vue.prototype.$user=new user();
Vue.prototype.$http = axios.create({
	baseURL:'https://localhost:5001/api'
});

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
