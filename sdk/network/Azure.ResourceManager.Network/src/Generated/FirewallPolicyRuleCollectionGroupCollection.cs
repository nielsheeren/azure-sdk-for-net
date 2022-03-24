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

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing a collection of <see cref="FirewallPolicyRuleCollectionGroupResource" /> and their operations.
    /// Each <see cref="FirewallPolicyRuleCollectionGroupResource" /> in the collection will belong to the same instance of <see cref="FirewallPolicyResource" />.
    /// To get a <see cref="FirewallPolicyRuleCollectionGroupCollection" /> instance call the GetFirewallPolicyRuleCollectionGroups method from an instance of <see cref="FirewallPolicyResource" />.
    /// </summary>
    public partial class FirewallPolicyRuleCollectionGroupCollection : ArmCollection, IEnumerable<FirewallPolicyRuleCollectionGroupResource>, IAsyncEnumerable<FirewallPolicyRuleCollectionGroupResource>
    {
        private readonly ClientDiagnostics _firewallPolicyRuleCollectionGroupClientDiagnostics;
        private readonly FirewallPolicyRuleCollectionGroupsRestOperations _firewallPolicyRuleCollectionGroupRestClient;

        /// <summary> Initializes a new instance of the <see cref="FirewallPolicyRuleCollectionGroupCollection"/> class for mocking. </summary>
        protected FirewallPolicyRuleCollectionGroupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FirewallPolicyRuleCollectionGroupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FirewallPolicyRuleCollectionGroupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _firewallPolicyRuleCollectionGroupClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", FirewallPolicyRuleCollectionGroupResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FirewallPolicyRuleCollectionGroupResource.ResourceType, out string firewallPolicyRuleCollectionGroupApiVersion);
            _firewallPolicyRuleCollectionGroupRestClient = new FirewallPolicyRuleCollectionGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, firewallPolicyRuleCollectionGroupApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != FirewallPolicyResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, FirewallPolicyResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates the specified FirewallPolicyRuleCollectionGroup.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}
        /// Operation Id: FirewallPolicyRuleCollectionGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleCollectionGroupName"> The name of the FirewallPolicyRuleCollectionGroup. </param>
        /// <param name="parameters"> Parameters supplied to the create or update FirewallPolicyRuleCollectionGroup operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleCollectionGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleCollectionGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<FirewallPolicyRuleCollectionGroupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string ruleCollectionGroupName, FirewallPolicyRuleCollectionGroupData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionGroupName, nameof(ruleCollectionGroupName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _firewallPolicyRuleCollectionGroupRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionGroupName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<FirewallPolicyRuleCollectionGroupResource>(new FirewallPolicyRuleCollectionGroupOperationSource(Client), _firewallPolicyRuleCollectionGroupClientDiagnostics, Pipeline, _firewallPolicyRuleCollectionGroupRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionGroupName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Creates or updates the specified FirewallPolicyRuleCollectionGroup.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}
        /// Operation Id: FirewallPolicyRuleCollectionGroups_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="ruleCollectionGroupName"> The name of the FirewallPolicyRuleCollectionGroup. </param>
        /// <param name="parameters"> Parameters supplied to the create or update FirewallPolicyRuleCollectionGroup operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleCollectionGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleCollectionGroupName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<FirewallPolicyRuleCollectionGroupResource> CreateOrUpdate(WaitUntil waitUntil, string ruleCollectionGroupName, FirewallPolicyRuleCollectionGroupData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionGroupName, nameof(ruleCollectionGroupName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _firewallPolicyRuleCollectionGroupRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionGroupName, parameters, cancellationToken);
                var operation = new NetworkArmOperation<FirewallPolicyRuleCollectionGroupResource>(new FirewallPolicyRuleCollectionGroupOperationSource(Client), _firewallPolicyRuleCollectionGroupClientDiagnostics, Pipeline, _firewallPolicyRuleCollectionGroupRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionGroupName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Gets the specified FirewallPolicyRuleCollectionGroup.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}
        /// Operation Id: FirewallPolicyRuleCollectionGroups_Get
        /// </summary>
        /// <param name="ruleCollectionGroupName"> The name of the FirewallPolicyRuleCollectionGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleCollectionGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleCollectionGroupName"/> is null. </exception>
        public virtual async Task<Response<FirewallPolicyRuleCollectionGroupResource>> GetAsync(string ruleCollectionGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionGroupName, nameof(ruleCollectionGroupName));

            using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.Get");
            scope.Start();
            try
            {
                var response = await _firewallPolicyRuleCollectionGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionGroupName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FirewallPolicyRuleCollectionGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified FirewallPolicyRuleCollectionGroup.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}
        /// Operation Id: FirewallPolicyRuleCollectionGroups_Get
        /// </summary>
        /// <param name="ruleCollectionGroupName"> The name of the FirewallPolicyRuleCollectionGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleCollectionGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleCollectionGroupName"/> is null. </exception>
        public virtual Response<FirewallPolicyRuleCollectionGroupResource> Get(string ruleCollectionGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionGroupName, nameof(ruleCollectionGroupName));

            using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.Get");
            scope.Start();
            try
            {
                var response = _firewallPolicyRuleCollectionGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionGroupName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FirewallPolicyRuleCollectionGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all FirewallPolicyRuleCollectionGroups in a FirewallPolicy resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups
        /// Operation Id: FirewallPolicyRuleCollectionGroups_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FirewallPolicyRuleCollectionGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FirewallPolicyRuleCollectionGroupResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<FirewallPolicyRuleCollectionGroupResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _firewallPolicyRuleCollectionGroupRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FirewallPolicyRuleCollectionGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FirewallPolicyRuleCollectionGroupResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _firewallPolicyRuleCollectionGroupRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FirewallPolicyRuleCollectionGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all FirewallPolicyRuleCollectionGroups in a FirewallPolicy resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups
        /// Operation Id: FirewallPolicyRuleCollectionGroups_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FirewallPolicyRuleCollectionGroupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FirewallPolicyRuleCollectionGroupResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<FirewallPolicyRuleCollectionGroupResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _firewallPolicyRuleCollectionGroupRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FirewallPolicyRuleCollectionGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FirewallPolicyRuleCollectionGroupResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _firewallPolicyRuleCollectionGroupRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FirewallPolicyRuleCollectionGroupResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}
        /// Operation Id: FirewallPolicyRuleCollectionGroups_Get
        /// </summary>
        /// <param name="ruleCollectionGroupName"> The name of the FirewallPolicyRuleCollectionGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleCollectionGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleCollectionGroupName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string ruleCollectionGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionGroupName, nameof(ruleCollectionGroupName));

            using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(ruleCollectionGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}
        /// Operation Id: FirewallPolicyRuleCollectionGroups_Get
        /// </summary>
        /// <param name="ruleCollectionGroupName"> The name of the FirewallPolicyRuleCollectionGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleCollectionGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleCollectionGroupName"/> is null. </exception>
        public virtual Response<bool> Exists(string ruleCollectionGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionGroupName, nameof(ruleCollectionGroupName));

            using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(ruleCollectionGroupName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}
        /// Operation Id: FirewallPolicyRuleCollectionGroups_Get
        /// </summary>
        /// <param name="ruleCollectionGroupName"> The name of the FirewallPolicyRuleCollectionGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleCollectionGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleCollectionGroupName"/> is null. </exception>
        public virtual async Task<Response<FirewallPolicyRuleCollectionGroupResource>> GetIfExistsAsync(string ruleCollectionGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionGroupName, nameof(ruleCollectionGroupName));

            using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _firewallPolicyRuleCollectionGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<FirewallPolicyRuleCollectionGroupResource>(null, response.GetRawResponse());
                return Response.FromValue(new FirewallPolicyRuleCollectionGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}/ruleCollectionGroups/{ruleCollectionGroupName}
        /// Operation Id: FirewallPolicyRuleCollectionGroups_Get
        /// </summary>
        /// <param name="ruleCollectionGroupName"> The name of the FirewallPolicyRuleCollectionGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="ruleCollectionGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="ruleCollectionGroupName"/> is null. </exception>
        public virtual Response<FirewallPolicyRuleCollectionGroupResource> GetIfExists(string ruleCollectionGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ruleCollectionGroupName, nameof(ruleCollectionGroupName));

            using var scope = _firewallPolicyRuleCollectionGroupClientDiagnostics.CreateScope("FirewallPolicyRuleCollectionGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _firewallPolicyRuleCollectionGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, ruleCollectionGroupName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<FirewallPolicyRuleCollectionGroupResource>(null, response.GetRawResponse());
                return Response.FromValue(new FirewallPolicyRuleCollectionGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FirewallPolicyRuleCollectionGroupResource> IEnumerable<FirewallPolicyRuleCollectionGroupResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FirewallPolicyRuleCollectionGroupResource> IAsyncEnumerable<FirewallPolicyRuleCollectionGroupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
