<template>
	<div class="d-flex justify-content-center align-items-center h-100" style="background-color:black">
		<div class="flex-column align-items-center login">
			<div class="mt-5 x15">LogIN e<span style="color:green">Cafe</span></div>
			<div class="mt-3 mb-3"><input type="text" placeholder="Email :" v-model="email"></div>
			<div class="mb-3"><input type="password" placeholder="Password :" v-model="password"></div>
			<button class="mb-5 btn btn-outline-primary" @click="login">Confirm</button>
		</div>
	</div>
</template>
<script type="text/javascript">
import goTo from '../../mixins/goTo'
export default{
	mixins:[goTo],
	methods:{
		login(){
			this.$http.post('auth/login',{email:this.email,password:this.password}).then(response=>{
				console.log(response);
				var user=response.data;
				this.$user.create(user);
				this.$user.login();
				console.log(this.$user);
				console.log(this.$user.role());
				if(this.$user.role()=="manager"){
					this.goTo('admin.manager')
				}
				this.goTo(this.$user.role());
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