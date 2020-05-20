import store from '../store/store'

import user from '../views/user/user'
import userRestaurants from '../views/user/restaurant/main'
import userRestaurant from '../views/user/restaurant/single'

import about from '../views/user/about/main'
import menu from '../views/user/menu/main'

import admin from '../views/administration/admin/admin'
import adminRestaurants from '../views/administration/admin/restaurants/restaurants'
import adminManagers from '../views/administration/admin/managers/managers'
import adminClients from '../views/administration/admin/clients/clients'

import manager from '../views/administration/manager/welcome'
import managerRouter from '../views/administration/manager/manager'
import managerFood from '../views/administration/manager/food/food'
import managerTables from '../views/administration/manager/tables/tables'
import managerRestaurant from '../views/administration/manager/restaurant/restaurant'

import login from '../views/auth/login'
import register from '../views/auth/register'

import profile from '../views/shared/profile/profile'
import profileDashboard from '../views/shared/profile/dashboard'
import profileSettings from '../views/shared/profile/settings'

import error from '../views/shared/error'

export const routes = 
[{
	name:'admin',
	path:'/admin',
	component:admin,
	beforeEnter:(to,from,next)=>{
		store.commit('initializeStore');
		if(store.state.user.role!='admin'){
			next({name:'error'});
		}
		else{
			next();
		}
	},
	children:[
	{
		name:'admin.restaurants',
		path:'restaurants',
		component:adminRestaurants,
		redirect:{name:'restaurants.dashboard'},
		meta:{
			display:'Restaurants',
			index:0
		},
		children:
		[{
			name:'restaurants.dashboard',
			path:'dashboard',
			component:require('../views/administration/admin/restaurants/dashboard.vue').default,
			meta:{
				display:'Dashboard'
			}
		},
		{
			name:'restaurants.settings',
			path:'settings',
			component:require('../views/administration/admin/restaurants/settings.vue').default,
			meta:{
				display:'Settings'
			}
		}]
	},
	{
		name:'admin.managers',
		path:'managers',
		component:adminManagers,
		redirect:{name:'managers.dashboard'},
		meta:{
			display:'Managers',
			index:1
		},
		children:
		[{
			name:'managers.dashboard',
			path:'dashboard',
			component:require('../views/administration/admin/managers/dashboard.vue').default,
			meta:{
				display:'Dashboard'
			}
		},
		{
			name:'managers.settings',
			path:'settings',
			component:require('../views/administration/admin/managers/settings.vue').default,
			meta:{
				display:'Settings'
			}
		}]
	},
	{
		name:'admin.clients',
		path:'clients',
		component:adminClients,
		redirect:{name:'clients.dashboard'},
		meta:{
			display:'Clients',
			index:2
		},
		children:
		[{
			name:'clients.dashboard',
			path:'dashboard',
			component:require('../views/administration/admin/clients/dashboard.vue').default,
			meta:{
				display:'Dashboard'
			}
		}]

	}]
},
{
	name:'manager',
	path:'/manager',
	component:manager,
	meta:{
		display:"Restaurants"
	},
	beforeEnter:(to,from,next)=>{
		store.commit('initializeStore');
		if(store.state.user.role!='manager'){
			next({name:'error'});
		}
		else{
			next();
		}
	},
},
{
	name:'manager.router',
	path:'/manager/edit',
	component:managerRouter,
	beforeEnter:(to,from,next)=>{
		store.commit('initializeStore');
		if(store.state.user.role!='manager'){
			next({name:'error'});
		}
		else{
			next();
		}
	},
	redirect:{name:'manager.food'},
	children:
	[{
		name:'manager.food',
		path:'food',
		component:managerFood,
		redirect:{name:'food.dashboard'},
		meta:{
			display:'Menu',
			index:0
		},
		children:
		[{
			name:'food.dashboard',
			path:'dashboard',
			component:require('../views/administration/manager/food/dashboard.vue').default,
			meta:{
				display:'Dashboard'
			}
		},
		{
			name:'food.settings',
			path:'settings',
			component:require('../views/administration/manager/food/settings.vue').default,
			props:true,
			meta:{
				display:'Settings'
			}
		}]
	},
	{
		name:'manager.tables',
		path:'tables',
		component:managerTables,
		redirect:{name:'tables.dashboard'},
		meta:{
			display:'Tables',
			index:1
		},
		children:
		[{
			name:'tables.dashboard',
			path:'dashboard',
			component:require('../views/administration/manager/tables/dashboard.vue').default,
			meta:{
				display:'Dashboard'
			}
		},
		{
			name:'tables.settings',
			path:'settings',
			component:require('../views/administration/manager/tables/settings.vue').default,
			meta:{
				display:'Settings'
			}
		}]
	},
	{
		name:'manager.restaurant',
		path:'restaurant',
		component:managerRestaurant,
		redirect:{name:'restaurant.settings'},
		meta:{
			display:'Restaurant',
			index:2
		},
		children:
		[{
			name:'restaurant.settings',
			path:'settings',
			component:require('../views/administration/manager/restaurant/settings.vue').default,
			props:true,
			meta:{
				display:'Settings'
			}
		}]
	}]
},
{
	name:'client',
	path:'/',
	component:user,
	redirect:{name:'about'},
	beforeEnter:(to,from,next)=>{
		store.commit('initializeStore');
		if(store.state.user.role=='admin' || store.state.user.role=='manager'){
			next({name:'login'});
		}
		else{
			next();
		}
	},
	children:
	[{
		name:'client.restaurant',
		path:'restaurant',
		component:userRestaurant,
		props:true
	},
	{
		name:'about',
		path:'about',
		component:about,
		meta:{
			display:'About',
			icon:'newspaper'
		},
	},
	{
		name:'menu',
		path:'menu',
		component:menu,
		meta:{
			display:'Menu',
			icon:'utensils'
		},

	},
	{
		name:'client.restaurants',
		path:'restaurants',
		component:userRestaurants,
		meta:{
			display:'Restaurants',
			icon:'glass-cheers'
		},
	}]
},
{
	name:'profile',
	path:'/account',
	component:profile,
	children:[{
		name:'profile.dashboard',
		path:'dashboard',
		component:profileDashboard
	},
	{
		name:'profile.settings',
		path:'settings',
		component:profileSettings
	},
	]
},
{
	name:'register',
	path:'/register',
	component:register
},
{
	name:'login',
	path:'/login',
	component:login
},
{
	name:'error',
	path:'*',
	component:error
}
]
