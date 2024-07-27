﻿using EcomSCAPI.Services.Dtos.Composition;
using EcomSCAPI.Models;

namespace EcomSCAPI.Services.Contract
{
    public interface ICompositionOperation
    {
        void UpdateComposition(IEnumerable<UpdateCompositionRequest>? compositionCollection, ICollection<Composition>? existingCompositionsfromDb);

        Task DeleteProductCompositions(int productId);

        Task DeleteCompositionFromProductByCompositionIdAsync(int productId, int compositionId);

        Task DeleteMediaFromCompositionByMediaIdAsync(int compositionId, int mediaId);

        Task DeletePriceFromCompositionByPriceIdAsync(int compositionId, int priceId);

        Task DeleteSizeFromCompositionBySizeIdAsync(int compositionId, int sizeId);

        Task ResetDiscountOfCompositionPriceByPriceIdAsync(int compositionId, int priceId);
    }
}