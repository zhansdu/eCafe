<template>
	<div id="app">
		<router-view></router-view>
	</div>
</template>
<script type="text/javascript">
export default{
	beforeRouteEnter(to,from,next) {
		this.$store.commit('initializeStore');
	}
};
</script>