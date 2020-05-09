<template>
	<div class="dropdown">
		<button class="btn dropdown-toggle" @click="toggle=!toggle">Profile<span class="caret"></span></button>
		<ul class="dropdown-menu dropdown-menu-right cursor-pointer" v-if="toggle">
			<li class="dropdown-item" @click="goTo('profile')">Account</li>
			<li class="dropdown-divider" />
			<li class="dropdown-item" @click="logout" v-if="$user.authenticated()">Logout</li>
			<li class="dropdown-item" @click="goTo('login')" v-else>Login</li>
			<li class="dropdown-item" @click="goTo('register')" >Register</li>
		</ul>
	</div>	
</template>
<script>
import goTo from '../mixins/goTo'
export default{
	mixins:[goTo],
	data(){
		return{
			toggle:false
		}
	},
	methods:{
		logout(){
			this.$user.logout();
			this.goTo('login');
		}
	}
};
</script>
<style scoped>
.dropdown-menu{
	display: block !important;
}
</style>