<template>
	<div class="flex-row">
		<div id="sidebar" v-if="toggle">
		</div>
		<div class="main">
			<div id="navbar">
				<div class="flex-row justify-content-between borderBottom h-100 x13">
					<div class="flex-row ml-2">
						<div class="x15 mr-4 pb-1 cursor-pointer"><span>&#9776;</span></div>
						<div class="w-100 flex-row align-items-center justify-content-around">
							<div class="cursor-pointer mr-2" v-for="route in routes[2].children" @click="goTo(route.name)" style="color:grey !important;">{{route.meta.display}}</div>
						</div>
					</div>
					<div class="flex-row mr-4">
						<div><icon icon="bell"></icon></div>
						<div class="ml-3"><icon icon="comment-dots"></icon></div>
					</div>
				</div>
				<div class="flex-row align-items-center borderBottom p-1 pl-3">
					<div><span style="color:#63B6D0;">HOME </span> / {{$route.meta.display}}</div>
				</div>
			</div>
			<router-view/>
		</div>
	</div>
</template>
<script type="text/javascript">
import {routes} from '../../router/routes'
import goTo from '../../mixins/goTo'
export default{
	mixins:[goTo],
	data(){
		return{
			routes,
			toggle:true
		}
	},
	created(){
		console.log(this.$route);
	}
};
</script>
<style scoped>
.main{
	width:80vw;
}
#sidebar{
	background: #5A6D8A;
	height: 100vh;
}
#sidebar,#navbar{
	position: sticky;
	top:0;
}
#navbar{
	display: flex;
	flex-direction: column;
	width:100%;
	z-index: 2;
	background-color: white;
}
#navbar > div{
	align-items:  center;
}
.borderBottom{
	border-bottom:2px solid gray;
}
</style>