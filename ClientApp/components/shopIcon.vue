<template>
	<div class="dropdown">
		<icon icon="shopping-basket" class="x13 position-relative" @click="toggle=!toggle"/>
		<div class="countItem" v-if="food.length>0"/>
		<ul class="dropdown-menu dropdown-menu-right" v-if="toggle">
			<li class="dropdown-divider" v-if="food.length>0"/>
			<li class="dropdown-item flex-row align-items-center" v-for="(food,index) in food">
				<div style="overflow:hidden;width:250px;">
					{{food.type}} {{food.name}} {{food.price}}
				</div>
				<icon icon="trash" @click="remove(index)"/>
			</li>
			<li class="dropdown-divider" v-if="food.length>0"/>
			<li class="dropdown-item" v-if="food.length>0">Total price : {{total}}</li>
		</ul>
	</div>	
</template>
<script>
import {mapGetters} from 'vuex'

import goTo from '../mixins/goTo'

export default{
	mixins:[goTo],
	data(){
		return{
			toggle:false
		}
	},
	computed:{
		total(){
			var int=0;
			if(this.food.length>0){
				this.food.forEach(elem=>{
					int+=elem.price;
				})
			}
			return int;
		},
		...mapGetters({
			food: 'getFood'
		})
	},
	methods:{
		remove(index){
			this.$store.commit('removeFood',index)
		}
	}
};
</script>
<style scoped>
.dropdown-menu{
	display: block !important;
}
.countItem{
	position: absolute;
	top:5px;
	right:-3px;
	border-radius: 50em;
	color:white;
	background-color: red;
	font-size: .5em;
	width:1em;
	height:1em;
}
</style>