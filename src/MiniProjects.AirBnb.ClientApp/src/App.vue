<template>

    <home-view/>

</template>

<script lang="ts" setup>
import HomeView from "@/common/views/HomeView.vue";
import { onMounted } from "vue";
import { UserInfoService } from "@/infrastructure/service/UserInfoService";

const userInfoService = new UserInfoService();

onMounted(() => {
    if (!userInfoService.isUserInfoSet())
        userInfoService.set();
})
</script>