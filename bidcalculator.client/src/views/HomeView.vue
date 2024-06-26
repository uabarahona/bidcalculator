<template>
  <main class="h-full grid grid-cols-2 px-0">
    <div class="bg-zinc-50 flex flex-col justify-center px-20">
      <BidInformation @on-changed="handleBidRequestChange" />
    </div>
    <div class="flex flex-col justify-center">
      <TotalCostBreakdown :total-cost-data="totalCostData" />
    </div>
  </main>
</template>


<script setup lang="ts">
import type { BidRequest, CarCostResponse } from '@/types/models';
import { ref } from 'vue'
import BidInformation from '@/components/BidInformation.vue';
import TotalCostBreakdown from '@/components/TotalCostBreakdown.vue';

const totalCostData = ref<CarCostResponse | undefined>()

async function handleBidRequestChange(bidRequest: BidRequest) : Promise<void>
{
  try {
      const response = await fetch("api/bids/totalCost", {
        headers: {
          'Content-Type': 'application/json'
        },
        method: "POST",
        body: JSON.stringify(bidRequest)
      })
      
      totalCostData.value = (await response.json())
    }
    catch(error)
    {

    } 
}
</script>
