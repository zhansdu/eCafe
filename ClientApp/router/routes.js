import user from '../views/user/main'
import restourants from '../views/user/restourant/main'
import restourant from '../views/user/restourant/single'
import about from '../views/user/about/main'
import menu from '../views/user/menu/main'
import map from '../views/user/map/main'


import admin from '../views/admin/main'
import dashboard from '../views/admin/dashboard/main'
import settings from '../views/admin/settings/main'
import users from '../views/admin/users/main'


import login from '../views/login/main'


export const routes = [
{
	name:'login',
	path:'/',
	component:login
},
{
	name:'mistake',
	path:'*',
	component:login
},
{
	name:'admin',
	path:'/admin',
	component:admin,
	redirect:{name:'dashboard'},
	children:[
	{
		name:'dashboard',
		path:'dashboard',
		component:dashboard,
		meta:{
			display:'Dashboard'
		}
	},
	{
		name:'users',
		path:'users',
		component:users,
		meta:{
			display:'Users'
		}
	},
	{
		name:'settings',
		path:'settings',
		component:settings,
		meta:{
			display:'Settings'
		}
	}
	]
},
{
	name:'user',
	path:'/user/',
	component:user,
	redirect:{name:'about'},
	children:[
	{
		name:'restourant',
		path:'restourant',
		component:restourant
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
		name:'restourants',
		path:'restourants',
		component:restourants,
		meta:{
			display:'Restourants',
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
}
]
