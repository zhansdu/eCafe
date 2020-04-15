import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store/store'
import { sync } from 'vuex-router-sync'
import App from './App'
import { FontAwesomeIcon } from './icons'

// Registration of global components
Vue.component('icon', FontAwesomeIcon)

Vue.prototype.$http = axios

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
