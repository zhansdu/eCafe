<template>
	<div class="x15 mr-4 pb-1 cursor-pointer" @click="clickHandle">
		<span>&#9776;</span>
	</div>
</template>
<script>
export default{
	methods:{
		clickHandle(){
			var sidebar = document.getElementById('sidebar');
			var main = document.getElementById('main');
			if(main.style.width!='100vw'){
				main.style.width='100vw';
				sidebar.style.width='0';
				sidebar.style.minWidth='0';
			}
			else{
				main.style.width='80vw';
				sidebar.style.width='20vw';
				sidebar.style.minWidth='200px';
			}
		}
	}
};
</script>