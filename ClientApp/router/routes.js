import user from '../views/user/main'
import userRestaurants from '../views/user/restaurant/main'
import userRestaurant from '../views/user/restaurant/single'
import about from '../views/user/about/main'
import menu from '../views/user/menu/main'
import map from '../views/user/map/main'

import admin from '../views/admin/admin/admin'
import adminRestaurants from '../views/admin/admin/restaurants/restaurants'
import adminManagers from '../views/admin/admin/managers/managers'
import adminClients from '../views/admin/admin/clients/clients'

import login from '../views/login/main'


export const routes = 
[{
	name:'login',
	path:'/',
	component:login
},
{
	name:'mistake',
	path:'/mistake',
	component:login
},
{
	name:'admin',
	path:'/admin',
	component:admin,
	redirect:{name:'admin.restaurants'},
	children:
	[{
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
			component:require('../views/admin/admin/restaurants/dashboard.vue').default,
			meta:{
				display:'Dashboard'
			}
		},
		{
			name:'restaurants.settings',
			path:'settings',
			component:require('../views/admin/admin/restaurants/settings.vue').default,
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
			component:require('../views/admin/admin/managers/dashboard.vue').default,
			meta:{
				display:'Dashboard'
			}
		},
		{
			name:'managers.settings',
			path:'settings',
			component:require('../views/admin/admin/managers/settings.vue').default,
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
			component:require('../views/admin/admin/clients/dashboard.vue').default,
			meta:{
				display:'Dashboard'
			}
		}]

	}]
},
{
	name:'user',
	path:'/user/',
	component:user,
	redirect:{name:'about'},
	children:[
	{
		name:'user.restaurant',
		path:'restaurant',
		component:userRestaurant
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
		name:'user.restaurants',
		path:'restaurants',
		component:userRestaurants,
		meta:{
			display:'Restaurants',
			icon:'glass-cheers'
		},
	},
	{
		name:'map',
		path:'map',
		component:map,
		meta:{
			display:'Map',
			icon:'globe'
		},
	}
	]
}]
