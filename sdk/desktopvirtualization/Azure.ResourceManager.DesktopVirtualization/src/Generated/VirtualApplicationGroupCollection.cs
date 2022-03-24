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

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A class representing a collection of <see cref="VirtualApplicationGroupResource" /> and their operations.
    /// Each <see cref="VirtualApplicationGroupResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="VirtualApplicationGroupCollection" /> instance call the GetVirtualApplicationGroups method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class VirtualApplicationGroupCollection : ArmCollection, IEnumerable<VirtualApplicationGroupResource>, IAsyncEnumerable<VirtualApplicationGroupResource>
    {
        private readonly ClientDiagnostics _virtualApplicationGroupApplicationGroupsClientDiagnostics;
        private readonly ApplicationGroupsRestOperations _virtualApplicationGroupApplicationGroupsRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualApplicationGroupCollection"/> class for mocking. </summary>
        protected VirtualApplicationGroupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualApplicationGroupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualApplicationGroupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualApplicationGroupApplicationGroupsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.DesktopVirtualization", VirtualApplicationGroupResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(VirtualApplicationGroupResource.ResourceType, out string virtualApplicationGroupApplicationGroupsApiVersion);
            _virtualApplicationGroupApplicationGroupsRestClient = new ApplicationGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, virtualApplicationGroupApplicationGroupsApiVersion);
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
        /// Create or update an applicationGroup.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}
        /// Operation Id: ApplicationGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="applicationGroupName"> The name of the application group. </param>
        /// <param name="applicationGroup"> Object containing ApplicationGroup definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationGroupName"/> or <paramref name="applicationGroup"/> is null. </exception>
        public virtual async Task<ArmOperation<VirtualApplicationGroupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string applicationGroupName, VirtualApplicationGroupData applicationGroup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGroupName, nameof(applicationGroupName));
            Argument.AssertNotNull(applicationGroup, nameof(applicationGroup));

            using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualApplicationGroupApplicationGroupsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationGroupName, applicationGroup, cancellationToken).ConfigureAwait(false);
                var operation = new DesktopVirtualizationArmOperation<VirtualApplicationGroupResource>(Response.FromValue(new VirtualApplicationGroupResource(Client, response), response.GetRawResponse()));
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
        /// Create or update an applicationGroup.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}
        /// Operation Id: ApplicationGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="applicationGroupName"> The name of the application group. </param>
        /// <param name="applicationGroup"> Object containing ApplicationGroup definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationGroupName"/> or <paramref name="applicationGroup"/> is null. </exception>
        public virtual ArmOperation<VirtualApplicationGroupResource> CreateOrUpdate(WaitUntil waitUntil, string applicationGroupName, VirtualApplicationGroupData applicationGroup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGroupName, nameof(applicationGroupName));
            Argument.AssertNotNull(applicationGroup, nameof(applicationGroup));

            using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualApplicationGroupApplicationGroupsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, applicationGroupName, applicationGroup, cancellationToken);
                var operation = new DesktopVirtualizationArmOperation<VirtualApplicationGroupResource>(Response.FromValue(new VirtualApplicationGroupResource(Client, response), response.GetRawResponse()));
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
        /// Get an application group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}
        /// Operation Id: ApplicationGroups_Get
        /// </summary>
        /// <param name="applicationGroupName"> The name of the application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationGroupName"/> is null. </exception>
        public virtual async Task<Response<VirtualApplicationGroupResource>> GetAsync(string applicationGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGroupName, nameof(applicationGroupName));

            using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualApplicationGroupApplicationGroupsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationGroupName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualApplicationGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an application group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}
        /// Operation Id: ApplicationGroups_Get
        /// </summary>
        /// <param name="applicationGroupName"> The name of the application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationGroupName"/> is null. </exception>
        public virtual Response<VirtualApplicationGroupResource> Get(string applicationGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGroupName, nameof(applicationGroupName));

            using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualApplicationGroupApplicationGroupsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, applicationGroupName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualApplicationGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List applicationGroups.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups
        /// Operation Id: ApplicationGroups_ListByResourceGroup
        /// </summary>
        /// <param name="filter"> OData filter expression. Valid properties for filtering are applicationGroupType. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualApplicationGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualApplicationGroupResource> GetAllAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualApplicationGroupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualApplicationGroupApplicationGroupsRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualApplicationGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualApplicationGroupResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualApplicationGroupApplicationGroupsRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualApplicationGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List applicationGroups.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups
        /// Operation Id: ApplicationGroups_ListByResourceGroup
        /// </summary>
        /// <param name="filter"> OData filter expression. Valid properties for filtering are applicationGroupType. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualApplicationGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualApplicationGroupResource> GetAll(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<VirtualApplicationGroupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualApplicationGroupApplicationGroupsRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualApplicationGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualApplicationGroupResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualApplicationGroupApplicationGroupsRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualApplicationGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}
        /// Operation Id: ApplicationGroups_Get
        /// </summary>
        /// <param name="applicationGroupName"> The name of the application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationGroupName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string applicationGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGroupName, nameof(applicationGroupName));

            using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(applicationGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}
        /// Operation Id: ApplicationGroups_Get
        /// </summary>
        /// <param name="applicationGroupName"> The name of the application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationGroupName"/> is null. </exception>
        public virtual Response<bool> Exists(string applicationGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGroupName, nameof(applicationGroupName));

            using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(applicationGroupName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}
        /// Operation Id: ApplicationGroups_Get
        /// </summary>
        /// <param name="applicationGroupName"> The name of the application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationGroupName"/> is null. </exception>
        public virtual async Task<Response<VirtualApplicationGroupResource>> GetIfExistsAsync(string applicationGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGroupName, nameof(applicationGroupName));

            using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualApplicationGroupApplicationGroupsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, applicationGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualApplicationGroupResource>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualApplicationGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}
        /// Operation Id: ApplicationGroups_Get
        /// </summary>
        /// <param name="applicationGroupName"> The name of the application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationGroupName"/> is null. </exception>
        public virtual Response<VirtualApplicationGroupResource> GetIfExists(string applicationGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationGroupName, nameof(applicationGroupName));

            using var scope = _virtualApplicationGroupApplicationGroupsClientDiagnostics.CreateScope("VirtualApplicationGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualApplicationGroupApplicationGroupsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, applicationGroupName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualApplicationGroupResource>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualApplicationGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualApplicationGroupResource> IEnumerable<VirtualApplicationGroupResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualApplicationGroupResource> IAsyncEnumerable<VirtualApplicationGroupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
