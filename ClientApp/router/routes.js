import user from '../views/user/main'
import restourant from '../views/user/restourant/main'
import about from '../views/user/about/main'
import menu from '../views/user/menu/main'
import map from '../views/user/map/main'


import admin from '../views/admin/main'


import login from '../views/login/main'


export const routes = [
{
	name:'login',
	path:'/',
	component:login
},
{
	name:'admin',
	path:'/admin',
	component:user
},
{
	name:'user',
	path:'/user',
	component:user,
	children:[
	{
		name:'about',
		path:'/',
		component:about,
		display:'About'
	},
	{
		name:'menu',
		path:'/menu',
		component:menu,
		display:'Menu'
	},
	{
		name:'restourant',
		path:'/restourant',
		component:restourant,
		display:'Restourants'
	},
	{
		name:'map',
		path:'/map',
		component:map,
		display:'Map'
	}
	]
}
]
