<template>
	<div class="flex-column">
		<div class="imageBrand"/>
		<div class="restourantGrid" style="margin-top:2vw;">
			<div class="restourantCard" v-for="(restourant,index) in restourants" :key="index">
				<div class="imageTitle" :style="'background-image:url('+restourant.image+');'"/>
				<div class="flex-column w-100 p-3">
					<div class="x15 align-self-center">Bahca-Sarai</div>
					<div>
						<div class="line"/>
						<div class="flex-column">
							<div>Working time : dofiga</div>
							<div>Kitchen is italian and french</div>
							<div>Avarage income:none</div>
						</div>
					</div>
					<button class="button align-self-center text-center cursor-pointer" @click="goTo('client.restaurant')">More</button>
				</div>
			</div>
		</div>
		<div class="flex-row justify-content-center" style="margin-top:2vw;margin-bottom:2vw;">
			<button class="squareButton x15 pink-button"> Order a Table</button>
			<button class="squareButton x15 purple-button ml-3"> Order Food</button>
		</div>
	</div>
</template>
<script type="text/javascript">
import goTo from '../../../mixins/goTo'
export default{
	mixins:[goTo],
	data(){
		return{
			restourants:[
			{
				image:'../static/divan.png'
			},
			{
				image:'../static/divan.png'
			},
			{
				image:'../static/divan.png'
			},
			{
				image:'../static/divan.png'
			},
			{
				image:'../static/divan.png'
			},
			{
				image:'../static/divan.png'
			}
			]
		}
	},
	methdos:{
		getImgUrl(pic) {
			return require(pic)
		}
	}
};
</script>
<style scoped>
.restourantCard{
	background: linear-gradient(180deg, #FFFFFF 0%, rgba(255, 255, 255, 0) 100%), #FFE9D6;
	border-radius: 3px;
	display: flex;
	flex-direction: column;
}
.line{
	border:1px solid black;
}
.button{
	border-radius: 10em;
	border-color: transparent;
	padding:3px;
	background-color: rgba(0,0,0,0.5);
	width:100px;
}
.squareButton{
	border-color: transparent;
}
.restourantGrid{
	display: grid;
	grid-template-columns: auto auto auto;
	grid-gap: 1vw;
}
.imageBrand{
	background-image: url('../../../assets/images/tarelka.png');
	background-size: cover;
	background-repeat: no-repeat;
	width: 100%;
	min-height: 218px;
	height:30vw;
}
.imageTitle{
	background-size: contain;
	background-repeat: no-repeat;
	width: 100%;
	min-height: 100px;
	height:15vw;
	border-radius: 15px;
}
</style>