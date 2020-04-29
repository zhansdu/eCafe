<template>
	<div class="d-flex justify-content-center align-items-center h-100" style="background-color:black">
		<div class="flex-column align-items-center login">
			<div class="mt-5 x15">Register IN e<span style="color:green">Cafe</span></div>
			<div class="mt-3 mb-3 flex-row">
				<input type="text" placeholder="First name :" v-model="user.firstName">
				<input class="ml-2" type="text" placeholder="Last name :" v-model="user.lastName">
			</div>
			<div class="mt-3 mb-3 flex-row">
				<input type="email" placeholder="Email :" v-model="user.email">
				<input class="ml-2" type="number" placeholder="Phone number :" v-model="user.phoneNumber">
			</div>
			<div class="mt-3 mb-3 flex-row">
				<input type="password" placeholder="Password :" v-model="user.password">
			</div>
			<button class="mb-5 btn btn-outline-primary" @click="register">Confirm</button>
		</div>
	</div>
</template>
<script type="text/javascript">
import goTo from '../../mixins/goTo'
export default{
	mixins:[goTo],
	data(){
		return{
			user:{
				role:"client"
			}
		}
	},
	methods:{
		register(){
			this.$http.post('auth/register',this.user).then(response=>{
				alert(response.statusText);
				this.goTo('login');
			})
		}
	}
};
</script>
<style scoped>
.login{
	flex: 0.5;
	min-width: 300px;
	min-height:250px;
	border:1px solid black;
	border-radius: 15px;
	background-color: lightblue;
}
</style>