<template>
	<div class="flex-row">
		<div id="sidebar">
			<div class="flex-column" style="margin-top:100px;">
				<div class="cursor-pointer ml-2 pl-3 p-1 mb-2 pilled" @click="getRestaurants()">{{$route.meta.display}}</div>
			</div>
		</div>
		<div id="main">
			<div id="navbar">
				<div class="flex-row justify-content-between borderBottom h-100 x13">
					<div class="flex-row ml-2">
						<toggler />
						<div class="flex-row align-items-center">Welcome {{$user.user().firstName}} {{$user.user().lastName}}</div>
					</div>
					<div class="flex-row mr-4">
						<dropdown />
					</div>
				</div>
			</div>
			<div class="p-3">	
				<div class="table">
					<div class="text-center">Restaurants</div>
					<div class="flex-row">
						<div class="col-1 text-center">Number</div>
						<div class="col-4 text-center">Name</div>
						<div class="col-4 text-center">City</div>
						<div class="col-3 flex-row justify-content-around">
							Editing
						</div>
					</div>
					<div class="flex-row" v-for="(restaurant,index) in restaurants" :key="index">
						<div class="col-1 text-center">{{index+1}}</div>
						<div class="col-4 text-center">{{restaurant.name}}</div>
						<div class="col-4 text-center">{{restaurant.city.name}}</div>
						<div class="col-3 flex-row justify-content-around">
							<div class="cursor-pointer" @click="edit(restaurant)"><icon icon="pen"/></div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>
<script type="text/javascript">
import goTo from '../../../mixins/goTo'
import toggler from '../../../components/toggler'
import dropdown from '../../../components/dropdown'
export default{
	mixins:[goTo],
	components:{toggler,dropdown},
	data(){
		return{
			index:0,
			restaurants:[]
		}
	},
	methods:{
		getRestaurants(){
			var id=this.$user.user().managerId
			this.$http.get('manager/restaurants/'+id).then(response=>{
				this.restaurants=response.data;
			})
		},
		edit(restaurant){
			this.$store.commit('setEditingRestaurant',restaurant);
			this.goTo('manager.food');
		}
	},
	created(){
		this.getRestaurants();
	}
};
</script>
<style scoped>
#navbar > div{
	align-items:  center;
}
#navbar{
	height:9.5vh;
	min-height: 50px;
}
#sidebar{
	background:#5A6D8A;
}
.pilled{
	background-color:rgba(0,0,0,0.4);
	border-top-left-radius:15px; 
	border-bottom-left-radius:15px; 
}
</style>