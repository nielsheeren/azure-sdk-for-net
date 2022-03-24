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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EdgeOrder
{
    /// <summary>
    /// A class representing a collection of <see cref="AddressResource" /> and their operations.
    /// Each <see cref="AddressResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get an <see cref="AddressResourceCollection" /> instance call the GetAddressResources method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class AddressResourceCollection : ArmCollection, IEnumerable<AddressResource>, IAsyncEnumerable<AddressResource>
    {
        private readonly ClientDiagnostics _addressResourceClientDiagnostics;
        private readonly EdgeOrderManagementRestOperations _addressResourceRestClient;

        /// <summary> Initializes a new instance of the <see cref="AddressResourceCollection"/> class for mocking. </summary>
        protected AddressResourceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AddressResourceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AddressResourceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _addressResourceClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.EdgeOrder", AddressResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(AddressResource.ResourceType, out string addressResourceApiVersion);
            _addressResourceRestClient = new EdgeOrderManagementRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, addressResourceApiVersion);
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
        /// Creates a new address with the specified parameters. Existing address can be updated with this API
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses/{addressName}
        /// Operation Id: CreateAddress
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="addressName"> The name of the address Resource within the specified resource group. address names must be between 3 and 24 characters in length and use any alphanumeric and underscore only. </param>
        /// <param name="addressResource"> Address details from request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="addressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="addressName"/> or <paramref name="addressResource"/> is null. </exception>
        public virtual async Task<ArmOperation<AddressResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string addressName, AddressResourceData addressResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(addressName, nameof(addressName));
            Argument.AssertNotNull(addressResource, nameof(addressResource));

            using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _addressResourceRestClient.CreateAddressAsync(Id.SubscriptionId, Id.ResourceGroupName, addressName, addressResource, cancellationToken).ConfigureAwait(false);
                var operation = new EdgeOrderArmOperation<AddressResource>(new AddressResourceOperationSource(Client), _addressResourceClientDiagnostics, Pipeline, _addressResourceRestClient.CreateCreateAddressRequest(Id.SubscriptionId, Id.ResourceGroupName, addressName, addressResource).Request, response, OperationFinalStateVia.Location);
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
        /// Creates a new address with the specified parameters. Existing address can be updated with this API
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses/{addressName}
        /// Operation Id: CreateAddress
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="addressName"> The name of the address Resource within the specified resource group. address names must be between 3 and 24 characters in length and use any alphanumeric and underscore only. </param>
        /// <param name="addressResource"> Address details from request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="addressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="addressName"/> or <paramref name="addressResource"/> is null. </exception>
        public virtual ArmOperation<AddressResource> CreateOrUpdate(WaitUntil waitUntil, string addressName, AddressResourceData addressResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(addressName, nameof(addressName));
            Argument.AssertNotNull(addressResource, nameof(addressResource));

            using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _addressResourceRestClient.CreateAddress(Id.SubscriptionId, Id.ResourceGroupName, addressName, addressResource, cancellationToken);
                var operation = new EdgeOrderArmOperation<AddressResource>(new AddressResourceOperationSource(Client), _addressResourceClientDiagnostics, Pipeline, _addressResourceRestClient.CreateCreateAddressRequest(Id.SubscriptionId, Id.ResourceGroupName, addressName, addressResource).Request, response, OperationFinalStateVia.Location);
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
        /// Gets information about the specified address.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses/{addressName}
        /// Operation Id: GetAddressByName
        /// </summary>
        /// <param name="addressName"> The name of the address Resource within the specified resource group. address names must be between 3 and 24 characters in length and use any alphanumeric and underscore only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="addressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="addressName"/> is null. </exception>
        public virtual async Task<Response<AddressResource>> GetAsync(string addressName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(addressName, nameof(addressName));

            using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.Get");
            scope.Start();
            try
            {
                var response = await _addressResourceRestClient.GetAddressByNameAsync(Id.SubscriptionId, Id.ResourceGroupName, addressName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AddressResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets information about the specified address.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses/{addressName}
        /// Operation Id: GetAddressByName
        /// </summary>
        /// <param name="addressName"> The name of the address Resource within the specified resource group. address names must be between 3 and 24 characters in length and use any alphanumeric and underscore only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="addressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="addressName"/> is null. </exception>
        public virtual Response<AddressResource> Get(string addressName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(addressName, nameof(addressName));

            using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.Get");
            scope.Start();
            try
            {
                var response = _addressResourceRestClient.GetAddressByName(Id.SubscriptionId, Id.ResourceGroupName, addressName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AddressResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all the addresses available under the given resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses
        /// Operation Id: ListAddressesAtResourceGroupLevel
        /// </summary>
        /// <param name="filter"> $filter is supported to filter based on shipping address properties. Filter supports only equals operation. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of addresses, which provides the next page in the list of address. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AddressResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AddressResource> GetAllAsync(string filter = null, string skipToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<AddressResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _addressResourceRestClient.ListAddressesAtResourceGroupLevelAsync(Id.SubscriptionId, Id.ResourceGroupName, filter, skipToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<AddressResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _addressResourceRestClient.ListAddressesAtResourceGroupLevelNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, skipToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new AddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all the addresses available under the given resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses
        /// Operation Id: ListAddressesAtResourceGroupLevel
        /// </summary>
        /// <param name="filter"> $filter is supported to filter based on shipping address properties. Filter supports only equals operation. </param>
        /// <param name="skipToken"> $skipToken is supported on Get list of addresses, which provides the next page in the list of address. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AddressResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AddressResource> GetAll(string filter = null, string skipToken = null, CancellationToken cancellationToken = default)
        {
            Page<AddressResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _addressResourceRestClient.ListAddressesAtResourceGroupLevel(Id.SubscriptionId, Id.ResourceGroupName, filter, skipToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<AddressResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _addressResourceRestClient.ListAddressesAtResourceGroupLevelNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, skipToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new AddressResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses/{addressName}
        /// Operation Id: GetAddressByName
        /// </summary>
        /// <param name="addressName"> The name of the address Resource within the specified resource group. address names must be between 3 and 24 characters in length and use any alphanumeric and underscore only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="addressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="addressName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string addressName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(addressName, nameof(addressName));

            using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(addressName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses/{addressName}
        /// Operation Id: GetAddressByName
        /// </summary>
        /// <param name="addressName"> The name of the address Resource within the specified resource group. address names must be between 3 and 24 characters in length and use any alphanumeric and underscore only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="addressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="addressName"/> is null. </exception>
        public virtual Response<bool> Exists(string addressName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(addressName, nameof(addressName));

            using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(addressName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses/{addressName}
        /// Operation Id: GetAddressByName
        /// </summary>
        /// <param name="addressName"> The name of the address Resource within the specified resource group. address names must be between 3 and 24 characters in length and use any alphanumeric and underscore only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="addressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="addressName"/> is null. </exception>
        public virtual async Task<Response<AddressResource>> GetIfExistsAsync(string addressName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(addressName, nameof(addressName));

            using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _addressResourceRestClient.GetAddressByNameAsync(Id.SubscriptionId, Id.ResourceGroupName, addressName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<AddressResource>(null, response.GetRawResponse());
                return Response.FromValue(new AddressResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/addresses/{addressName}
        /// Operation Id: GetAddressByName
        /// </summary>
        /// <param name="addressName"> The name of the address Resource within the specified resource group. address names must be between 3 and 24 characters in length and use any alphanumeric and underscore only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="addressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="addressName"/> is null. </exception>
        public virtual Response<AddressResource> GetIfExists(string addressName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(addressName, nameof(addressName));

            using var scope = _addressResourceClientDiagnostics.CreateScope("AddressResourceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _addressResourceRestClient.GetAddressByName(Id.SubscriptionId, Id.ResourceGroupName, addressName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<AddressResource>(null, response.GetRawResponse());
                return Response.FromValue(new AddressResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AddressResource> IEnumerable<AddressResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AddressResource> IAsyncEnumerable<AddressResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
