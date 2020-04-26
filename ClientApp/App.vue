<template>
	<div id="app">
		<router-view></router-view>
	</div>
</template>
<script type="text/javascript">
export default{
	beforeCreate() {
		this.$store.commit('initializeStore');
	}
};
</script>