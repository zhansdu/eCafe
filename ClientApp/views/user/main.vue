<template>
	<div class="flex-row position-relative h-100">
		<div id="sidebar" class="flex-column">
			<div class="mt-3">
				<div v-for="(route,index) in routes[2].children" :key="index">
					<div class="pt-3 pl-3 pr-3">{{route.display}}</div>
				</div>
			</div>
		</div>
		<div id="sidebarImage"></div>
		<div class="flex-column main pl-2">
			<div class="flex-row">
				<div class="flex-column">
					<div class="mt-2"><span class="x2">&#9776;</span></div>
				</div>
				<div class="flex-column p-3 justify-content-around">
					<div>About us</div>
					<div>Menu</div>
					<div>For Sale</div>
					<div>News</div>
					<div>Contacts</div>
				</div>
				<div class="flex-column logo"></div>
				<div class="flex-column"></div>
				<div class="flex-column"></div>
			</div>
			<router-view></router-view>
		</div>
	</div>
</template>
<script type="text/javascript">
import {routes} from '../../router/routes'
export default{
	data(){
		return{
			routes
		}
	}
};
</script>
<style scoped>
.logo{
	background-image: url('../../assets/images/logo.png');
	background-size: contain;
	background-repeat: no-repeat;
	width: 238px;
}
#sidebar,#sidebarImage{
	width:20vw;
	height: 100%;
	min-width: 200px;
}
#sidebar{
	position: fixed;
	background: linear-gradient(180deg, #A34D42 0%, transparent 100%), #FFFFFF;
}
.main{
	width:80vw;
}
@media only screen and (min-width: 768px){
	#sidebarImage{
		display: block;
	}
}
</style>