<template>
	<div class="d-flex justify-content-center align-items-center h-100" style="background-color:black">
		<div class="flex-column align-items-center login">
			<div class="mt-5 mb-3 x15">LogIN e<span style="color:green">Cafe</span></div>
			<div class="mb-3"><input type="email" placeholder="Email" v-model="email"></div>
			<div class="mb-3"><input type="password" placeholder="Password" v-model="password"></div>
			<button class="mb-3 btn btn-outline-primary" @click="login">Confirm</button>
			<div class="mb-5">Or <router-link :to="{ name: 'register'}"> Register</router-link></div>
		</div>
	</div>
</template>
<script type="text/javascript">
import goTo from '../../mixins/goTo'
export default{
	mixins:[goTo],
	data(){
		return{
			email:null,
			password:null
		}
	},
	methods:{
		login(){
			var auth={email:this.email,password:this.password}
			this.$http.post('auth/login',auth).then(response=>{
				if(response.data=="not found"){
					alert(response.data);
				}
				else{
					this.$user.login(response.data);
					this.goTo(this.$user.role());
				}
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