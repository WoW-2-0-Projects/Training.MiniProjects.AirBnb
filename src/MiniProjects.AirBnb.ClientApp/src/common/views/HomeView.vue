<template>

    <div class="theme-bg-primary h-screen">

        <!-- Header-->
        <main-header/>

        <!-- Content -->
        <article class="mt-[20px] bg-defaultBackground content-padding">



        </article>

        <!-- Content -->

        <!--    <locations-container/>-->

        <button class="mt-20" @click="appThemeService.toggleDarkMode()">Dark mode</button>

    </div>

</template>

<script setup lang="ts">
import MainHeader from "@/common/components/MainHeader.vue";
import { AppThemeService } from "@/infrastructure/service/AppThemeService";

// import LocationsContainer from "@/modules/locations/components/LocationsContainer.vue";


const appThemeService = new AppThemeService();

</script>