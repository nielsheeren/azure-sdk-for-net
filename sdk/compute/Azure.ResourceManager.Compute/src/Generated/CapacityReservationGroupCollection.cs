// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A class representing a collection of <see cref="CapacityReservationGroupResource" /> and their operations.
    /// Each <see cref="CapacityReservationGroupResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="CapacityReservationGroupCollection" /> instance call the GetCapacityReservationGroups method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class CapacityReservationGroupCollection : ArmCollection, IEnumerable<CapacityReservationGroupResource>, IAsyncEnumerable<CapacityReservationGroupResource>
    {
        private readonly ClientDiagnostics _capacityReservationGroupClientDiagnostics;
        private readonly CapacityReservationGroupsRestOperations _capacityReservationGroupRestClient;

        /// <summary> Initializes a new instance of the <see cref="CapacityReservationGroupCollection"/> class for mocking. </summary>
        protected CapacityReservationGroupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="CapacityReservationGroupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal CapacityReservationGroupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _capacityReservationGroupClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", CapacityReservationGroupResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(CapacityReservationGroupResource.ResourceType, out string capacityReservationGroupApiVersion);
            _capacityReservationGroupRestClient = new CapacityReservationGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, capacityReservationGroupApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// The operation to create or update a capacity reservation group. When updating a capacity reservation group, only tags may be modified. Please refer to https://aka.ms/CapacityReservation for more details.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups/{capacityReservationGroupName}
        /// Operation Id: CapacityReservationGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="capacityReservationGroupName"> The name of the capacity reservation group. </param>
        /// <param name="parameters"> Parameters supplied to the Create capacity reservation Group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capacityReservationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capacityReservationGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<CapacityReservationGroupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string capacityReservationGroupName, CapacityReservationGroupData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capacityReservationGroupName, nameof(capacityReservationGroupName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _capacityReservationGroupRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, capacityReservationGroupName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ComputeArmOperation<CapacityReservationGroupResource>(Response.FromValue(new CapacityReservationGroupResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation to create or update a capacity reservation group. When updating a capacity reservation group, only tags may be modified. Please refer to https://aka.ms/CapacityReservation for more details.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups/{capacityReservationGroupName}
        /// Operation Id: CapacityReservationGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="capacityReservationGroupName"> The name of the capacity reservation group. </param>
        /// <param name="parameters"> Parameters supplied to the Create capacity reservation Group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capacityReservationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capacityReservationGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<CapacityReservationGroupResource> CreateOrUpdate(WaitUntil waitUntil, string capacityReservationGroupName, CapacityReservationGroupData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capacityReservationGroupName, nameof(capacityReservationGroupName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _capacityReservationGroupRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, capacityReservationGroupName, parameters, cancellationToken);
                var operation = new ComputeArmOperation<CapacityReservationGroupResource>(Response.FromValue(new CapacityReservationGroupResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation that retrieves information about a capacity reservation group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups/{capacityReservationGroupName}
        /// Operation Id: CapacityReservationGroups_Get
        /// </summary>
        /// <param name="capacityReservationGroupName"> The name of the capacity reservation group. </param>
        /// <param name="expand"> The expand expression to apply on the operation. &apos;InstanceView&apos; will retrieve the list of instance views of the capacity reservations under the capacity reservation group which is a snapshot of the runtime properties of a capacity reservation that is managed by the platform and can change outside of control plane operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capacityReservationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capacityReservationGroupName"/> is null. </exception>
        public virtual async Task<Response<CapacityReservationGroupResource>> GetAsync(string capacityReservationGroupName, CapacityReservationGroupInstanceViewTypes? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capacityReservationGroupName, nameof(capacityReservationGroupName));

            using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.Get");
            scope.Start();
            try
            {
                var response = await _capacityReservationGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, capacityReservationGroupName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CapacityReservationGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The operation that retrieves information about a capacity reservation group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups/{capacityReservationGroupName}
        /// Operation Id: CapacityReservationGroups_Get
        /// </summary>
        /// <param name="capacityReservationGroupName"> The name of the capacity reservation group. </param>
        /// <param name="expand"> The expand expression to apply on the operation. &apos;InstanceView&apos; will retrieve the list of instance views of the capacity reservations under the capacity reservation group which is a snapshot of the runtime properties of a capacity reservation that is managed by the platform and can change outside of control plane operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capacityReservationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capacityReservationGroupName"/> is null. </exception>
        public virtual Response<CapacityReservationGroupResource> Get(string capacityReservationGroupName, CapacityReservationGroupInstanceViewTypes? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capacityReservationGroupName, nameof(capacityReservationGroupName));

            using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.Get");
            scope.Start();
            try
            {
                var response = _capacityReservationGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, capacityReservationGroupName, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CapacityReservationGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all of the capacity reservation groups in the specified resource group. Use the nextLink property in the response to get the next page of capacity reservation groups.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups
        /// Operation Id: CapacityReservationGroups_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. Based on the expand param(s) specified we return Virtual Machine or ScaleSet VM Instance or both resource Ids which are associated to capacity reservation group in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CapacityReservationGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CapacityReservationGroupResource> GetAllAsync(ExpandTypesForGetCapacityReservationGroups? expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<CapacityReservationGroupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _capacityReservationGroupRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CapacityReservationGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<CapacityReservationGroupResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _capacityReservationGroupRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CapacityReservationGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists all of the capacity reservation groups in the specified resource group. Use the nextLink property in the response to get the next page of capacity reservation groups.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups
        /// Operation Id: CapacityReservationGroups_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> The expand expression to apply on the operation. Based on the expand param(s) specified we return Virtual Machine or ScaleSet VM Instance or both resource Ids which are associated to capacity reservation group in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CapacityReservationGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CapacityReservationGroupResource> GetAll(ExpandTypesForGetCapacityReservationGroups? expand = null, CancellationToken cancellationToken = default)
        {
            Page<CapacityReservationGroupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _capacityReservationGroupRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CapacityReservationGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<CapacityReservationGroupResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _capacityReservationGroupRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CapacityReservationGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups/{capacityReservationGroupName}
        /// Operation Id: CapacityReservationGroups_Get
        /// </summary>
        /// <param name="capacityReservationGroupName"> The name of the capacity reservation group. </param>
        /// <param name="expand"> The expand expression to apply on the operation. &apos;InstanceView&apos; will retrieve the list of instance views of the capacity reservations under the capacity reservation group which is a snapshot of the runtime properties of a capacity reservation that is managed by the platform and can change outside of control plane operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capacityReservationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capacityReservationGroupName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string capacityReservationGroupName, CapacityReservationGroupInstanceViewTypes? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capacityReservationGroupName, nameof(capacityReservationGroupName));

            using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(capacityReservationGroupName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups/{capacityReservationGroupName}
        /// Operation Id: CapacityReservationGroups_Get
        /// </summary>
        /// <param name="capacityReservationGroupName"> The name of the capacity reservation group. </param>
        /// <param name="expand"> The expand expression to apply on the operation. &apos;InstanceView&apos; will retrieve the list of instance views of the capacity reservations under the capacity reservation group which is a snapshot of the runtime properties of a capacity reservation that is managed by the platform and can change outside of control plane operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capacityReservationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capacityReservationGroupName"/> is null. </exception>
        public virtual Response<bool> Exists(string capacityReservationGroupName, CapacityReservationGroupInstanceViewTypes? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capacityReservationGroupName, nameof(capacityReservationGroupName));

            using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(capacityReservationGroupName, expand: expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups/{capacityReservationGroupName}
        /// Operation Id: CapacityReservationGroups_Get
        /// </summary>
        /// <param name="capacityReservationGroupName"> The name of the capacity reservation group. </param>
        /// <param name="expand"> The expand expression to apply on the operation. &apos;InstanceView&apos; will retrieve the list of instance views of the capacity reservations under the capacity reservation group which is a snapshot of the runtime properties of a capacity reservation that is managed by the platform and can change outside of control plane operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capacityReservationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capacityReservationGroupName"/> is null. </exception>
        public virtual async Task<Response<CapacityReservationGroupResource>> GetIfExistsAsync(string capacityReservationGroupName, CapacityReservationGroupInstanceViewTypes? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capacityReservationGroupName, nameof(capacityReservationGroupName));

            using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _capacityReservationGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, capacityReservationGroupName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<CapacityReservationGroupResource>(null, response.GetRawResponse());
                return Response.FromValue(new CapacityReservationGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/capacityReservationGroups/{capacityReservationGroupName}
        /// Operation Id: CapacityReservationGroups_Get
        /// </summary>
        /// <param name="capacityReservationGroupName"> The name of the capacity reservation group. </param>
        /// <param name="expand"> The expand expression to apply on the operation. &apos;InstanceView&apos; will retrieve the list of instance views of the capacity reservations under the capacity reservation group which is a snapshot of the runtime properties of a capacity reservation that is managed by the platform and can change outside of control plane operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capacityReservationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capacityReservationGroupName"/> is null. </exception>
        public virtual Response<CapacityReservationGroupResource> GetIfExists(string capacityReservationGroupName, CapacityReservationGroupInstanceViewTypes? expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capacityReservationGroupName, nameof(capacityReservationGroupName));

            using var scope = _capacityReservationGroupClientDiagnostics.CreateScope("CapacityReservationGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _capacityReservationGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, capacityReservationGroupName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<CapacityReservationGroupResource>(null, response.GetRawResponse());
                return Response.FromValue(new CapacityReservationGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<CapacityReservationGroupResource> IEnumerable<CapacityReservationGroupResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<CapacityReservationGroupResource> IAsyncEnumerable<CapacityReservationGroupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
