<template>
	<div class="flex-column">
		<div class="bgPurple">
			<img src="../../../assets/images/stoliki.png" class="image" />
			<div class="grid">
				<div class="flex-column align-items-center text-center">
					<div><icon icon="home" class="x15"/></div>
					<div class="x15">Адресс</div>
					<div class="x08">г. Шымкент пр. Тауке хана 121,</div>
					<div class="x08">угол ул.Жолдасбекова 24</div>
				</div>
				<div class="flex-column align-items-center text-center">
					<div><icon icon="phone-square" class="x15"/></div>
					<div class="x15">Контакты</div>
					<div class="x08">+7 7252 54-97-70</div>
					<div class="x08">+7 707 747-11-10</div>
				</div>
				<div class="flex-column align-items-center text-center">
					<div><icon icon="comment-dots" class="x15"/></div>
					<div class="x15">Столики</div>
					<div class="x08">Online оформление заявки </div>
					<div class="x08">на проведение мероприятия</div>
				</div>
				<div class="flex-column align-items-center text-center">
					<div><icon icon="shopping-basket"class="x15"/></div>
					<div class="x15">Доставка</div>
					<div class="x08">Служба доставки Ак-сарай </div>
					<div class="x08">+7 701 900-11-10</div>
				</div>
			</div>
		</div>
		<div class="flex-column align-items-center text-center">
			<div>Ak sarai</div>
			<div class="line"></div>
			<div class="x08">
				 Еще один колоритный ресторан узбекской кухни из семейства «Meyram Group». Большой, роскошный и яркий, как будто сохранившийся в веках величественный дворец. Оказавшись здесь, несложно почувствовать себя султаном на дворцовом пире с его цветистой восточной роскошью и яркими красками.<br><br> Ресторан подходит для любого случая и повода. Вы можете уединиться небольшой компанией на балконе, отпраздновать шумное и веселое торжество в банкетном зале, посидеть на топчанах, наслаждаясь вкусом наших блюд и неповторимой аурой эмирских дворцов Средней Азии.<br><br> Блюда, подаваемые к дастархану, под стать богатству убранства дворца. Вся щедрость узбекской кухни с ее отборным мясом, специями, несколькими сортами шашлыка, самсы, лепешек.Блюда Ташкента, Ферганы, Хивы, Бухары и других регионов Узбекистана - настоящее гастрономическое путешествие! Блюда, готовящиеся на открытом огне, наполняющие пространство пряными ароматами специй. Десятки видов салатов, закусок, горячих блюд, 17 видов шашлыка! Не уйдут недовольными и стойкие приверженцы европейской кухни, для них, как и для других требовательных гурманов, есть специальный раздел меню «Кухня народов мира». Над несколькими видами плова колдуют ошпазы из Ташкента, Андижана, Ферганы. <br><br>Еще одна особенность «Ак-Сарая» - сервис в духе восточного гостеприимства. Вы можете смело привозить своих гостей, приехавших из других городов или стран. Коллектив «Ак-Сарая» абсолютно уверен, что это посещение станет одним из самых незабываемых впечатлений от поездки в Южный Казахстан.
			</div>
		</div>
		<div class="grid bgPurple">
			<div class="flex-column align-items-center text-center">
				<div><icon icon="clock" class="x15"/></div>
				<div class="x15">Время работы</div>
				<div class="x08"> Пн-Вс - с 09:00 до 00:30</div>
			</div>
			<div class="flex-column align-items-center text-center">
				<div><icon icon="tags" class="x15"/></div>
				<div class="x15">Средний чек</div>
				<div class="x08"> 3000 тенге</div>
			</div>
			<div class="flex-column align-items-center text-center">
				<div><icon icon="utensils" class="x15"/></div>
				<div class="x15">Кухня</div>
				<div class="x08">Узбекская, европейская кухня</div>
			</div>
			<div class="flex-column align-items-center text-center">
				<div><icon icon="comment-dots" class="x15"/></div>
				<div class="x15">Оставить отзыв</div>
				<div class="x08"> Поделитесь впечатлениями</div>
			</div>
		</div>
		<div class="backgroundImage flex-column justify-content-center" :style="'background-image:url('+image+');'">
			<div class="half-width flex-column align-items-center ml-auto" style="height:80%;">
				<div class="innerDiv flex-column p-3">
					<div>О ресторане</div>
					<div class="x08">
						Атмосфера и Сервис в духе восточного гостеприимства позволят Вам почувствовать себя высокопочитаемым гостем, а окружающая роскошь и изысканность разнообразных угощений дадут Вам такое ощущение, словно Вы эмир или калиф. Другими словами, Вы сможете по-настоящему расслабиться и полноценно отдохнуть.
					</div>
					<div class="x08">
						 В Ак-Сарай Вы можете смело привозить своих гостей, приехавших к Вам из других городов или стран, мы абсолютно уверены, что именно посещение нашего ресторана останется для них одним из самых ярких впечатлений.
					</div>
				</div>
			</div>
		</div>
		<div class="flex-row justify-content-center">
			<button class="pink-button mr-2 x15">Zagruzit' menu</button>
			<button class="purple-button x15">Zagruzit' menu?</button>
		</div>
	</div>			
</template>
<style scoped>
.image{
	width:100%;
	min-width: 500px;
}
.grid{
	display: grid;
	grid-template-columns: 25% 25% 25% 25%;
}
.grid > div:nth-child(n+2){
	border-left:1px solid black;
}
.bgPurple{
	background: #FFE8E8;
}
.backgroundImage{
	background-repeat: no-repeat;
	background-size: cover;
	min-height: 210px;
	height:33vw;
}
.innerDiv{
	height: 100%;
	width:80%;
	background-color: rgba(255,255,255,0.5);
	overflow: scroll;
}
@media only screen and (min-width: 1185px){
	.innerDiv{
		justify-content: space-around;
	}
}
</style>
<script type="text/javascript">
export default{
	data(){
		return{
			image:'../static/bar.png'
		}
	}
};
</script>