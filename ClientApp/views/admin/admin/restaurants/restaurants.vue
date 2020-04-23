<template>
	<div>
		<div class="flex-row align-items-center borderBottom p-1 pl-3 position-sticky">
			<div><span style="color:#63B6D0;">RESTAURANTS</span> / {{$route.meta.display}}</div>
		</div>
		<router-view/>
	</div>
</template>