// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A Class representing an InstanceFailoverGroup along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct an <see cref="InstanceFailoverGroupResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetInstanceFailoverGroupResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetInstanceFailoverGroup method.
    /// </summary>
    public partial class InstanceFailoverGroupResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="InstanceFailoverGroupResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string locationName, string failoverGroupName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _instanceFailoverGroupClientDiagnostics;
        private readonly InstanceFailoverGroupsRestOperations _instanceFailoverGroupRestClient;
        private readonly InstanceFailoverGroupData _data;

        /// <summary> Initializes a new instance of the <see cref="InstanceFailoverGroupResource"/> class for mocking. </summary>
        protected InstanceFailoverGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "InstanceFailoverGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal InstanceFailoverGroupResource(ArmClient client, InstanceFailoverGroupData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="InstanceFailoverGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal InstanceFailoverGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _instanceFailoverGroupClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string instanceFailoverGroupApiVersion);
            _instanceFailoverGroupRestClient = new InstanceFailoverGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, instanceFailoverGroupApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/locations/instanceFailoverGroups";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual InstanceFailoverGroupData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets a failover group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}
        /// Operation Id: InstanceFailoverGroups_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<InstanceFailoverGroupResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupResource.Get");
            scope.Start();
            try
            {
                var response = await _instanceFailoverGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new InstanceFailoverGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a failover group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}
        /// Operation Id: InstanceFailoverGroups_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<InstanceFailoverGroupResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupResource.Get");
            scope.Start();
            try
            {
                var response = _instanceFailoverGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new InstanceFailoverGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a failover group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}
        /// Operation Id: InstanceFailoverGroups_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupResource.Delete");
            scope.Start();
            try
            {
                var response = await _instanceFailoverGroupRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation(_instanceFailoverGroupClientDiagnostics, Pipeline, _instanceFailoverGroupRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a failover group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}
        /// Operation Id: InstanceFailoverGroups_Delete
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupResource.Delete");
            scope.Start();
            try
            {
                var response = _instanceFailoverGroupRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SqlArmOperation(_instanceFailoverGroupClientDiagnostics, Pipeline, _instanceFailoverGroupRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Fails over from the current primary managed instance to this managed instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}/failover
        /// Operation Id: InstanceFailoverGroups_Failover
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<InstanceFailoverGroupResource>> FailoverAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupResource.Failover");
            scope.Start();
            try
            {
                var response = await _instanceFailoverGroupRestClient.FailoverAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<InstanceFailoverGroupResource>(new InstanceFailoverGroupOperationSource(Client), _instanceFailoverGroupClientDiagnostics, Pipeline, _instanceFailoverGroupRestClient.CreateFailoverRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Fails over from the current primary managed instance to this managed instance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}/failover
        /// Operation Id: InstanceFailoverGroups_Failover
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<InstanceFailoverGroupResource> Failover(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupResource.Failover");
            scope.Start();
            try
            {
                var response = _instanceFailoverGroupRestClient.Failover(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SqlArmOperation<InstanceFailoverGroupResource>(new InstanceFailoverGroupOperationSource(Client), _instanceFailoverGroupClientDiagnostics, Pipeline, _instanceFailoverGroupRestClient.CreateFailoverRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Fails over from the current primary managed instance to this managed instance. This operation might result in data loss.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}/forceFailoverAllowDataLoss
        /// Operation Id: InstanceFailoverGroups_ForceFailoverAllowDataLoss
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<InstanceFailoverGroupResource>> ForceFailoverAllowDataLossAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupResource.ForceFailoverAllowDataLoss");
            scope.Start();
            try
            {
                var response = await _instanceFailoverGroupRestClient.ForceFailoverAllowDataLossAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<InstanceFailoverGroupResource>(new InstanceFailoverGroupOperationSource(Client), _instanceFailoverGroupClientDiagnostics, Pipeline, _instanceFailoverGroupRestClient.CreateForceFailoverAllowDataLossRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Fails over from the current primary managed instance to this managed instance. This operation might result in data loss.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName}/forceFailoverAllowDataLoss
        /// Operation Id: InstanceFailoverGroups_ForceFailoverAllowDataLoss
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<InstanceFailoverGroupResource> ForceFailoverAllowDataLoss(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _instanceFailoverGroupClientDiagnostics.CreateScope("InstanceFailoverGroupResource.ForceFailoverAllowDataLoss");
            scope.Start();
            try
            {
                var response = _instanceFailoverGroupRestClient.ForceFailoverAllowDataLoss(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SqlArmOperation<InstanceFailoverGroupResource>(new InstanceFailoverGroupOperationSource(Client), _instanceFailoverGroupClientDiagnostics, Pipeline, _instanceFailoverGroupRestClient.CreateForceFailoverAllowDataLossRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name).Request, response, OperationFinalStateVia.Location);
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
    }
}
