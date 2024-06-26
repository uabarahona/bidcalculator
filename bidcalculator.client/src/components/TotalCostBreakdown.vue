<template>
    <div v-if="totalCostData" class="space-y-4 px-20">
        <div class="space-y-2">
            <dl class="flex items-center justify-between gap-4">
                <div>
                    <dt class="font-normal text-gray-800 ">Bid Amount</dt>
                    <dt class="font-normal text-xs text-gray-500 ">Car type: {{  totalCostData.carType }}</dt>
                </div>
                <dd class="font-medium text-gray-900 ">{{ formattedCost(totalCostData.bidAmount) }}</dd>
            </dl>
            <dl v-for="fee in totalCostData.fees" class="flex items-center justify-between gap-4">
                <div>
                    <dt class="font-normal text-gray-800 ">{{ fee.title }}</dt>
                    <dt class="font-normal text-xs text-gray-500 ">{{ fee.description }}</dt>
                </div>
                <dd class="font-medium text-gray-900 ">{{ formattedCost(fee.fee) }}</dd>
            </dl>
        </div>

        <dl class="flex items-center justify-between gap-4 border-t border-gray-200 pt-2">
            <dt class="text-lg font-bold text-gray-900">Total</dt>
            <dd class="text-lg font-bold text-gray-900"> {{ formattedCost(totalCostData.totalCost) }}</dd>
        </dl>
    </div>
    <div v-else class="mx-auto max-w-screen-sm">
        <h2 class="mb-4 text-4xl tracking-tight font-extrabold text-gray-900 ">Inser your bid.</h2>
        <p class="mb-8 font-light text-gray-500 text-xl">You must insert your bit to get the final price.</p>
    </div>
</template>

<script setup lang="ts">
import type { CarCostResponse } from '@/types/models';

defineProps<{
  totalCostData?: CarCostResponse
}>()

function formattedCost(cost : number): string {
    return cost.toLocaleString('en-US', {
            style: 'currency',
            currency: 'USD',
    });
}

</script>