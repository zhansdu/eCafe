<template>
	<div class="d-flex justify-content-center align-items-center h-100" style="background-color:black">
		<div class="flex-column align-items-center login">
			<div class="mt-5 x15">LogIN e<span style="color:green">Cafe</span></div>
			<div class="mt-3 mb-3"><input type="text" placeholder="Username :" v-model="username"></div>
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
			if(this.username=="client"){
				this.goTo('user');
			}
			else if(this.username=='admin'){
				this.goTo('admin');
			}
			else{
				alert('Mistake!');
			}
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