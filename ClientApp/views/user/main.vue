<template>
	<div class="flex-row position-relative h-100">
		<div id="sidebar" class="flex-column">
			<div class="mt-5">
				<div v-for="(route,index) in routes[3].children.slice(1)" :key="index" class="flex-row mt-2 ml-2 pt-2 pl-2 align-items-center cursor-pointer" @click="goTo(route.name)">
					<div style="width:20px;"><icon :icon="route.meta.icon"></icon></div>
					<div class="ml-2">{{route.meta.display}}</div>
				</div>
			</div>
		</div>
		<div id="sidebarImage"></div>
		<div class="flex-column main p-2">
			<div class="flex-row">
				<div class="flex-column">
					<div><span class="x2">&#9776;</span></div>
				</div>
				<div class="flex-row justify-content-around w-100">
					<div class="flex-column pl-3 justify-content-around">
						<div>About us</div>
						<div>Menu</div>
						<div>For Sale</div>
						<div>News</div>
						<div>Contacts</div>
					</div>
					<div class="flex-column logo"></div>
					<div class="flex-column justify-content-around">
						<customSelect placeholder="Choose your city"/>
						<button class="button x15">Order</button>
						<div class="flex-column">
							<span>8(707)270-13-03</span>
							<span>8(707)270-14-14</span>
						</div>
					</div>
				</div>
				<div class="flex-row">
					<div><icon icon="bell"></icon></div>
					<div class="ml-3"><icon icon="comment-dots"></icon></div>
				</div>
			</div>
			<router-view></router-view>
		</div>
	</div>
</template>
<script type="text/javascript">
import {routes} from '../../router/routes'
import customSelect from '../../components/customSelect'
import goTo from '../../mixins/goTo'
export default{
	mixins:[goTo],
	components:{
		customSelect
	},
	data(){
		return{
			routes
		}
	}
};
</script>
<style scoped>
.button{
	background: #FA7777;
	border-color: transparent;
}
.logo{
	background-image: url('../../assets/images/logo.png');
	background-size: contain;
	background-repeat: no-repeat;
	width: 238px;
	height:150px;
}
#sidebar{
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