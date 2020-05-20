<template>
	<div class="flex-row">
		<div id="sidebar">
			<div class="flex-column mt-5">
				<div v-for="(route,index) in routes[3].children.slice(1)" :key="index" class="flex-row mt-2 ml-2 pt-2 pl-2 align-items-center cursor-pointer" @click="goTo(route.name)">
					<div style="width:20px;"><icon :icon="route.meta.icon"></icon></div>
					<div class="ml-2">{{route.meta.display}}</div>
				</div>
			</div>
		</div>
		<div id="main">
			<div id="navbar" class="p-2">
				<div class="flex-row justify-content-between">
					<div style="width:33%;" class="flex-row">
						<toggler/>
						<div class="ml-2" style="width:150px;">
							<customSelect :options="cities.data" placeholder="Cities" v-model="city" :onChange="setCity"/>
						</div>
					</div>
					<div class="flex-column logo"></div>
					<div class="flex-row justify-content-end align-items-center" style="width:33%;height:30px">
						<shopIcon />
						<dropdown />
					</div>
				</div>
			</div>
			<router-view></router-view>
		</div>
	</div>
</div>
</template>
<script type="text/javascript">
import goTo from '../../mixins/goTo'

import {routes} from '../../router/routes'

import customSelect from '../../components/customSelect'
import dropdown from '../../components/dropdown'
import toggler from '../../components/toggler'
import shopIcon from '../../components/shopIcon'

export default{
	mixins:[goTo],
	components:{customSelect,dropdown,toggler,shopIcon},
	data(){
		return{
			routes,
			cities:[],
			city:this.$store.state.city
		}
	},
	methods:{
		setCity(){
			this.$store.commit('setCity',this.city);
		}
	},
	async created(){
		this.cities=await this.$http.get('admin/cities');
		this.cities.data.forEach(element=>{
			element.label=element.name;
		})
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
	min-width: 158px;
	height:100px;
}
#sidebar{
	background: linear-gradient(180deg, #A34D42 0%, transparent 100%), #FFFFFF;
}
</style>