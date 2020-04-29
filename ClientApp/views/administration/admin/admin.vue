<template>
	<div class="flex-row">
		<div id="sidebar">
			<div class="flex-column" style="margin-top:100px;">
				<div class="cursor-pointer ml-2 pl-3 p-1 mb-2 pilled" v-for="route in routes[2].children" @click="goTo(route.name);index=route.meta.index">{{route.meta.display}}</div>
			</div>
		</div>
		<div id="main">
			<div id="navbar">
				<div class="flex-row justify-content-between borderBottom h-100 x13">
					<div class="flex-row ml-2">
						<toggler />
						<div class="w-100 flex-row align-items-center justify-content-around">
							<div class="cursor-pointer mr-2" v-for="route in routes[2].children[index].children" @click="goTo(route.name)" style="color:grey !important;">{{route.meta.display}}</div>
						</div>
					</div>
					<div class="flex-row mr-4">
						<dropdown />
					</div>
				</div>
			</div>
			<router-view/>
		</div>
	</div>
</template>
<script type="text/javascript">
import {routes} from '../../../router/routes'
import goTo from '../../../mixins/goTo'
import toggler from '../../../components/toggler'
import dropdown from '../../../components/dropdown'
export default{
	mixins:[goTo],
	components:{toggler,dropdown},
	data(){
		return{
			routes,
			index:0
		}
	},
	created(){
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
.pilled{
	background-color:rgba(0,0,0,0.4);
	border-top-left-radius:15px; 
	border-bottom-left-radius:15px; 
}
</style>